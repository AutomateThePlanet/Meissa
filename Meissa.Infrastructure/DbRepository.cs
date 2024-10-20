// <copyright file="DbRepository.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Meissa.Infrastructure;

public abstract class DbRepository<TContext> : IRepository, IDisposable
where TContext : DbContext
{
    private readonly TContext _context;
    private readonly bool _shouldRefreshEntities;

    protected DbRepository(TContext context, bool shouldRefreshEntities = true)
    {
        _context = context;
        ////_context.ChangeTracker.AutoDetectChangesEnabled = false;
        _shouldRefreshEntities = shouldRefreshEntities;
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<TEntity> GetByIdAsync<TEntity>(int id)
    where TEntity : class
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        await RefreshEntityAsync(entity).ConfigureAwait(false);
        return entity;
    }

    public async Task<IQueryable<TEntity>> GetAllQueryWithRefreshAsync<TEntity>()
    where TEntity : class
    {
        await RefreshAllAsync<TEntity>().ConfigureAwait(false);
        return _context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAllQuery<TEntity>()
        where TEntity : class => _context.Set<TEntity>();

    public async Task DeleteByIdWithSaveAsync<TEntity>(int id, int retryCount = 3)
    where TEntity : class => await SaveChangesAsync(
        (context) =>
        {
            var entity = _context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(entity);
        },
        retryCount).ConfigureAwait(false);

    public void DeleteById<TEntity>(int id)
        where TEntity : class
    {
        var entity = _context.Set<TEntity>().Find(id);
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task DeleteWithSaveAsync<TEntity>(TEntity entityToBeRemoved, int retryCount = 3)
    where TEntity : class => await SaveChangesAsync(
        (context) =>
        {
            context.Set<TEntity>().Remove(entityToBeRemoved);
        },
        retryCount).ConfigureAwait(false);

    public async Task DeleteRangeWithSaveAsync<TEntity>(IEnumerable<TEntity> entitiesToBeDeleted, int retryCount = 3)
    where TEntity : class => await SaveChangesAsync(
        (context) => context.Set<TEntity>().RemoveRange(entitiesToBeDeleted),
        retryCount).ConfigureAwait(false);

    public void DeleteRange<TEntity>(IEnumerable<TEntity> entitiesToBeDeleted)
        where TEntity : class
        => _context.Set<TEntity>().RemoveRange(entitiesToBeDeleted);

    public async Task<TEntity> InsertWithSaveAsync<TEntity>(TEntity entityToBeInserted, int retryCount = 3)
    where TEntity : class
    {
        var insertedProxy =
                await SaveChangesAsync(
                                 context =>
                                 {
                                     context.Set<TEntity>().Add(entityToBeInserted);
                                     return entityToBeInserted;
                                 },
                                 retryCount).ConfigureAwait(false);
        return insertedProxy;
    }

    public void Insert<TEntity>(TEntity entityToBeInserted)
        where TEntity : class
    {
        _context.Set<TEntity>().Add(entityToBeInserted);
    }

    public async Task UpdateWithSaveAsync<TEntity>(TEntity entityToBeUpdated, int retryCount = 3)
    where TEntity : class => await SaveChangesAsync(
        context =>
        {
            context.Set<TEntity>().Attach(entityToBeUpdated);
            var entry = context.Entry(entityToBeUpdated);
            entry.State = EntityState.Modified;
        },
        retryCount).ConfigureAwait(false);

    public void Update<TEntity>(TEntity entityToBeUpdated)
        where TEntity : class
    {
        _context.Set<TEntity>().Attach(entityToBeUpdated);
        EntityEntry<TEntity> entry = _context.Entry(entityToBeUpdated);
        entry.State = EntityState.Modified;
    }

    private async Task SaveChangesAsync(Action<TContext> action, int retryCount = 3)
    {
        ////_context.ChangeTracker.AutoDetectChangesEnabled = false;
        action(_context);
        await SaveAsync(retryCount).ConfigureAwait(false);
    }

    private async Task<TEntity> SaveChangesAsync<TEntity>(Func<TContext, TEntity> function, int retryCount = 3)
    where TEntity : class
    {
        ////_context.ChangeTracker.AutoDetectChangesEnabled = false;
        var savedEntity = function(_context);
        await SaveAsync(retryCount).ConfigureAwait(false);
        return savedEntity;
    }

    public async Task SaveAsync(int retryCount = 3)
    {
        bool saveFailed;
        do
        {
            saveFailed = false;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                DetachAllEntities();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                saveFailed = true;
                Thread.Sleep(2000);
                retryCount--;
                if (retryCount == 0)
                {
                    throw;
                }

                //// Update the values of the entity that failed to save from the store
                if (ex.Entries != null && ex.Entries.Count > 0)
                {
                    await ex.Entries.Single().ReloadAsync().ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                saveFailed = true;
                Thread.Sleep(2000);
                retryCount--;
                if (retryCount == 0)
                {
                    throw;
                }
            }
        }
        while (saveFailed && retryCount >= 0);
    }

    private async Task RefreshEntityAsync<TEntity>(TEntity entityToBeRefreshed)
    where TEntity : class
    {
        if (entityToBeRefreshed != null && _shouldRefreshEntities)
        {
            await _context.Entry(entityToBeRefreshed).ReloadAsync().ConfigureAwait(false);
        }
    }

    private async Task RefreshAllAsync<TEntity>()
    where TEntity : class
    {
        if (_shouldRefreshEntities)
        {
            foreach (var entity in _context.ChangeTracker.Entries<TEntity>())
            {
                await entity.ReloadAsync().ConfigureAwait(false);
            }
        }
    }

    private void DetachAllEntities()
    {
        var changedEntriesCopy = _context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();
        foreach (var entity in changedEntriesCopy)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}

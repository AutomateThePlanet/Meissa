// <copyright file="IRepository.cs" company="Automate The Planet Ltd.">
// Copyright 2018 Automate The Planet Ltd.
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meissa.Core.Contracts
{
    public interface IRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(int id)
            where TEntity : class;

        Task<IQueryable<TEntity>> GetAllQueryWithRefreshAsync<TEntity>()
            where TEntity : class;

        Task<TEntity> InsertWithSaveAsync<TEntity>(TEntity entityToBeInserted, int retryCount = 1)
            where TEntity : class;

        void Insert<TEntity>(TEntity entityToBeInserted)
            where TEntity : class;

        Task UpdateWithSaveAsync<TEntity>(TEntity entityToBeUpdated, int retryCount = 1)
            where TEntity : class;

        void Update<TEntity>(TEntity entityToBeUpdated)
          where TEntity : class;

        IQueryable<TEntity> GetAllQuery<TEntity>()
            where TEntity : class;

        Task DeleteByIdWithSaveAsync<TEntity>(int id, int retryCount = 1)
        where TEntity : class;

        void DeleteById<TEntity>(int id)
            where TEntity : class;

        Task DeleteWithSaveAsync<TEntity>(TEntity entityToBeRemoved, int retryCount = 1)
            where TEntity : class;

        Task DeleteRangeWithSaveAsync<TEntity>(IEnumerable<TEntity> entitiesToBeDeleted, int retryCount = 1)
            where TEntity : class;

        void DeleteRange<TEntity>(IEnumerable<TEntity> entitiesToBeDeleted)
            where TEntity : class;

        Task SaveAsync(int retryCount = 3);
    }
}
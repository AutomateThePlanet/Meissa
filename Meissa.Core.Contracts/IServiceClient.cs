// <copyright file="IServiceClient.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Threading.Tasks;

namespace Meissa.Core.Contracts
{
    public interface IServiceClient<TEntityDto>
        where TEntityDto : class
    {
        Task<TEntityDto> GetAsync<TSearchCriteria>(TSearchCriteria searchCriteria);

        Task<IQueryable<TEntityDto>> GetAllAsync();

        Task DeleteAsync<TSearchCriteria>(TSearchCriteria id);

        Task<TEntityDto> CreateAsync(TEntityDto entityToBeCreated);

        Task UpdateAsync<TSearchCriteria>(TSearchCriteria id, TEntityDto entityToBeUpdatedDto);
    }
}
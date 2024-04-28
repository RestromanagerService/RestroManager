﻿using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.UnitsOfWork.implementations
{
    public class CategoriesUnitOfWork(IGenericRepository<Category> repository, ICategoriesRepository categoriesRepository) : GenericUnitOfWork<Category>(repository), ICategoriesUnitOfWork
    {
        private readonly ICategoriesRepository _categoriesRepository = categoriesRepository;


        public override async Task<ActionResponse<IEnumerable<Category>>> GetAsync(PaginationDTO pagination) =>
            await _categoriesRepository.GetAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _categoriesRepository.GetTotalPagesAsync(pagination);



    }
}

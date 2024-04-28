﻿using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class ProductRepository(DataContext dataContext) :GenericRepository<Product>(dataContext),IProductRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public override async Task<ActionResponse<Product>> GetAsync(int id)
        {
            var product= await _dataContext.Products
                .Include(p=>p.ProductFoods!)
                .ThenInclude(pf=>pf.Food)
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Units)
                .FirstOrDefaultAsync(p=>p.Id==id);
            if(product == null)
            {
                return new ActionResponse<Product>
                {
                    WasSuccess = false,
                    Message = "El producto no existe"
                };
            }
            return new ActionResponse<Product>
            {
                WasSuccess = true,
                Result = product
            };
        }

        public override async Task<ActionResponse<IEnumerable<Product>>> GetAsync()
        {
            var products = await _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = products
            };
        }
        public override async Task<ActionResponse<IEnumerable<Product>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };


        }

        public virtual async Task<ActionResponse<IEnumerable<Product>>> GetRecipesAsync()
        {
            var products = await _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .Where(p => p.ProductFoods != null && p.ProductFoods.Count != 0)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = products
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<Product>>> GetRecipesAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .Where(p => p.ProductFoods != null && p.ProductFoods.Count != 0)
                .AsQueryable();
            return new ActionResponse<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }
        public virtual async Task<ActionResponse<int>> GetRecipesTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .Where(p => p.ProductFoods != null && p.ProductFoods.Count != 0)
                .AsQueryable();
            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class ProductRepository(DataContext dataContext) : GenericRepository<Product>(dataContext), IProductRepository
    {
        private readonly DataContext _dataContext = dataContext;

        private ProductType? ConvertToProductType(int id)
        {
            if (Enum.IsDefined(typeof(ProductType), id))
            {
                return (ProductType)id;
            }
            return null;
        }

        public override async Task<ActionResponse<Product>> GetAsync(int id)
        {
            var product = await _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Units)
                .Include(p => p.ProductCategories!)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
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
                .Where(p => p.ProductType == Enums.ProductType.Recipe)
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
                .Where(p => p.ProductType == Enums.ProductType.Recipe)
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
        public virtual async Task<ActionResponse<int>> GetRecipesTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .Where(p => p.ProductType == Enums.ProductType.Recipe)
                .AsQueryable();

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
        public virtual async Task<ActionResponse<IEnumerable<Product>>> GetProductsByType(int id, PaginationDTO paginationDTO)
        {
            var productType = ConvertToProductType(id);
            if (productType == null)
            {
                return new ActionResponse<IEnumerable<Product>>
                {
                    WasSuccess = false,
                    Message = "Tipo de producto no válido"
                };
            }

            var queryable = _dataContext.Products
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Food)
                .Include(p => p.ProductFoods!)
                .ThenInclude(pf => pf.Units)
                .Where(p => p.ProductType == productType)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginationDTO.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(paginationDTO.Filter.ToLower()));
            }

            var products = await queryable.Paginate(paginationDTO).ToListAsync();

            if (!products.Any())
            {
                return new ActionResponse<IEnumerable<Product>>
                {
                    WasSuccess = false,
                    Message = "No hay productos para esta categoría"
                };
            }

            return new ActionResponse<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = products
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalProductsByTypeAsync(int id, PaginationDTO paginationDTO)
        {
            var productType = ConvertToProductType(id);
            if (productType == null)
            {
                return new ActionResponse<int>
                {
                    WasSuccess = false,
                    Message = "Tipo de producto no válido"
                };
            }

            var queryable = _dataContext.Products
                .Where(p => p.ProductType == productType)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginationDTO.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(paginationDTO.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / paginationDTO.RecordsNumber);

            if (count == 0)
            {
                return new ActionResponse<int>
                {
                    WasSuccess = false,
                    Message = "No hay productos para esta categoría"
                };
            }

            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }

        public override async Task<ActionResponse<Product>> UpdateAsync(Product entity)
        {


            try
            {
                await _dataContext.ProductCategories.Where(p => p.ProductId == entity.Id).ExecuteDeleteAsync();
                _dataContext.Update(entity);
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<Product>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }
        private ActionResponse<Product> ExceptionActionResponse(Exception exception)
        {
            return new ActionResponse<Product>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }

        private ActionResponse<Product> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<Product>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentando crear"
            };
        }
    }

}


using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class ProductFoodRepository(DataContext dataContext) :GenericRepository<ProductFood>(dataContext),IProductFoodRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public override async Task<ActionResponse<ProductFood>> GetAsync(int id)
        {
            var productFood = await _dataContext.ProductFoods
                .Include(pf=>pf.Food)
                .FirstOrDefaultAsync(pf => pf.Id == id);
            if(productFood == null)
            {
                return new ActionResponse<ProductFood>
                {
                    WasSuccess = false,
                    Message = "El alimento no esta relacionado con la receta"
                };
            }
            return new ActionResponse<ProductFood>
            {
                WasSuccess = true,
                Result = productFood
            };
        }
    }
}

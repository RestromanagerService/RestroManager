using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Implementations
{
    public class TemporalOrdersRepository : GenericRepository<TemporalOrder>, ITemporalOrdersRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _usersRepository;

        public TemporalOrdersRepository(DataContext context, IUserRepository usersRepository) : base(context)
        {
            _context = context;
            _usersRepository = usersRepository;
        }

        public async Task<ActionResponse<TemporalOrderDTO>> AddFullAsync(string email, TemporalOrderDTO temporalOrderDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == temporalOrderDTO.ProductId);
            if (product == null)
            {
                return new ActionResponse<TemporalOrderDTO>
                {
                    WasSuccess = false,
                    Message = "Producto no existe"
                };
            }

            var user = await _usersRepository.GetUserAsync(email);
            if (user == null)
            {
                return new ActionResponse<TemporalOrderDTO>
                {
                    WasSuccess = false,
                    Message = "Usuario no existe"
                };
            }
            var table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == temporalOrderDTO.TableId);
            if (table == null)
            {
                return new ActionResponse<TemporalOrderDTO>
                {
                    WasSuccess = false,
                    Message = "La mesa no existe"
                };
            }

            var temporalOrder = new TemporalOrder
            {
                Product = product,
                Quantity = temporalOrderDTO.Quantity,
                Table= table,
                User = user
            };
            var reg = await _context.TemporalOrders.FirstOrDefaultAsync(t => t.ProductId == product.Id && t.UserId == user.Id);
            try
            {
                if (reg == null)
                {
                    if (temporalOrderDTO.Quantity <= 0)
                    {
                        return new ActionResponse<TemporalOrderDTO>
                        {
                            WasSuccess = false,
                            Message = "La cantidad debe ser mayor a cero"
                        };
                    }
                    _context.Add(temporalOrder);
                }
                else
                {
                    reg.Quantity += temporalOrderDTO.Quantity;
                    reg.TableId= temporalOrderDTO.TableId;
                    if (reg.Quantity <= 0)
                    {
                        _context.TemporalOrders.Remove(reg);
                    }
                    else
                    {
                        _context.Update(reg);
                    }
                }
                await _context.SaveChangesAsync();
                return new ActionResponse<TemporalOrderDTO>
                {
                    WasSuccess = true,
                    Result = temporalOrderDTO
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<TemporalOrderDTO>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ActionResponse<IEnumerable<TemporalOrder>>> GetAsync(string email)
        {
            var temporalOrders = await _context.TemporalOrders
                .Include(ts => ts.User!)
                .Include(ts => ts.Product!)
                .ThenInclude(p => p.ProductCategories!)
                .ThenInclude(pc => pc.Category)
                .Include(ts => ts.Product!)
                .Where(x => x.User!.Email == email)
                .ToListAsync();

            return new ActionResponse<IEnumerable<TemporalOrder>>
            {
                WasSuccess = true,
                Result = temporalOrders
            };
        }

        public async Task<ActionResponse<int>> GetCountAsync(string email)
        {
            var count = await _context.TemporalOrders
                .Where(x => x.User!.Email == email)
                .SumAsync(x => x.Quantity);

            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }

    }
}

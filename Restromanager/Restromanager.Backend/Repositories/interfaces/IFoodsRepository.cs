﻿using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;

namespace Restromanager.Backend.Repositories.Interfaces
{
    public interface IFoodsRepository
    {
        Task<ActionResponse<Food>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Food>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}

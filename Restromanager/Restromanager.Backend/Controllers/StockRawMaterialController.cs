﻿using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockRawMaterialController(IGenericUnitOfWork<StockRawMaterial> unitOfWork) : GenericController<StockRawMaterial>(unitOfWork)
    {
    }
}

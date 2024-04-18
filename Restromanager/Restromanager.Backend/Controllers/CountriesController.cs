using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController(IGenericUnitOfWork<Country> unitOfWork) : GenericController<Country>(unitOfWork)
    {
    }
}

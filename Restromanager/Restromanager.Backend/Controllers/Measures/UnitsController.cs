using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Domain.Entities.Measures;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController(IGenericUnitOfWork<Unit> unitOfWork) : GenericController<Unit>(unitOfWork)
    {
    }
}

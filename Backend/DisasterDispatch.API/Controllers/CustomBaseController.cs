using DisasterDispatch.Core.Dtos.BaseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult ActionResultInstance<T>(CustomResponse<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}

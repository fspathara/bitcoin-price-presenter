using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BitcoinPricePresenter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class BaseController : ControllerBase
    {
    }
}

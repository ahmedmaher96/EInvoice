using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInvoice.API.Controllers.Generic
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIBaseController : ControllerBase
    {
    }
}

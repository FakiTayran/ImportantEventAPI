using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportantEventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportantEventController : ControllerBase
    {
        [HttpGet("GetImportantEvents")]
        public ActionResult GetImportantEvents()
        {
            return Ok();
        }
    }
}

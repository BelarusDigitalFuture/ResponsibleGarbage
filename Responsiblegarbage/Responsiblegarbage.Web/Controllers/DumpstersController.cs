using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Responsiblegarbage.Web.Services;

namespace Responsiblegarbage.Web.Controllers
{
    [Route("api/dumpsters")]
    [ApiController]
    public class DumpstersController : ControllerBase
    {
        private readonly IDumpsterService _dumpsterService;

        public DumpstersController(IDumpsterService dumpsterService)
        {
            _dumpsterService = dumpsterService ?? throw new ArgumentNullException(nameof(dumpsterService));
        }

        [HttpGet]
        public async Task<ActionResult> GetByProduct([FromQuery] int productId)
        {
            var dumpsters = await _dumpsterService.GetByProductAsync(productId);
            return Ok(dumpsters);
        }
    }
}

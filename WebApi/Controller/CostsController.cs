using Entity.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Utils;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CostsController : ControllerBase
    {
        private ICostsRepository CostsRepository { get; set; }
        public CostsController(
            ICostsRepository costs)
        {
            CostsRepository = costs;
        }

        [HttpGet]
        public async Task<IActionResult> GetCosts()
        {
            return Ok(await CostsRepository.GetCostsAsync(this.GetUserId()));
        }
    }
}

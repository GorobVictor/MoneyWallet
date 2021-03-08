using Core.Model;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await CostsRepository.GetCostsAsync(this.GetUserId()));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] List<Costs> costs)
        {
            await CostsRepository.AddCostsAsync(costs);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] List<Costs> costs)
        {
            await CostsRepository.UpdateCostsAsync(costs);
            return Ok();
        }
    }
}

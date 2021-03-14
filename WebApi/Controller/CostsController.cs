using AutoMapper;
using Core.Model;
using Core.Model.Dto;
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
        private IMapper Mapper { get; set; }
        public CostsController(
            ICostsRepository costs,
            IMapper mapper
            )
        {
            CostsRepository = costs;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(this.Mapper.Map<List<GetSetCosts>>(await CostsRepository.GetCostsAsync(this.GetUserId())));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] List<GetSetCosts> costs)
        {
            await CostsRepository.AddCostsAsync(costs, this.GetUserId());
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] List<GetSetCosts> costs)
        {
            await CostsRepository.UpdateCostsAsync(costs, this.GetUserId());
            return Ok();
        }
    }
}

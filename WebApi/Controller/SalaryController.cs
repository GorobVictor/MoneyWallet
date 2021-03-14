using AutoMapper;
using Core.Model;
using Core.Model.Dto;
using Core.Utils;
using Entity.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Utils;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalaryController : ControllerBase
    {
        private ISalaryRepository SalaryRepository { get; set; }
        private IMapper Mapper { get; set; }

        public SalaryController(
            ISalaryRepository salaryRepository,
            IMapper mapper
            )
        {
            SalaryRepository = salaryRepository;
            Mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(this.Mapper.Map<List<GetSetSalary>>(await SalaryRepository.GetSalaryAsync(this.GetUserId(), true)));
        }
        [HttpGet]
        [Route("getbydate")]
        public async Task<IActionResult> Get(DateTime? from, DateTime? to)
        {
            return Ok(this.Mapper.Map<List<GetSetSalary>>(await SalaryRepository.GetSalaryByDateAsync(this.GetUserId(), from, to, true)));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] List<GetSetSalary> objects)
        {
            await SalaryRepository.UpdateSalaryAsync(objects, this.GetUserId());
            return Ok();
        }
    }
}

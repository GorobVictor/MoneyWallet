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
        public SalaryController(ISalaryRepository salaryRepository)
        {
            SalaryRepository = salaryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await SalaryRepository.GetSalaryAsync(this.GetUserId(), true);

            var result = list.Select(x => 
            new GetSalaryResult(x, CurrencyParser.Convert(x.Currency,x.User.Currency,x.Value))
            ).ToArray();

            return Ok(result);
        }
        [HttpGet]
        [Route("getbydate")]
        public async Task<IActionResult> Get(DateTime? from, DateTime? to)
        {
            return Ok(await SalaryRepository.GetSalaryByDateAsync(this.GetUserId(), from, to));
        }
    }
}

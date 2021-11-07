using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RulesMicroservice.Models;
using RulesMicroservice.Services;

namespace RulesMicroservice.Controllers
{
    [Route("api")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        private readonly RulesService _service;

        public RulesController(RulesService service)
        {
            _service = service;
        }
        [Route("GetRules")]
        [HttpGet]
        public Task<string> GetRules(float balance, int accId)
        {
            var rule = _service.EvaluateMinBal(balance, accId);
            return rule;
        }
        [Route("GetCharges")]
        [HttpGet]
        public Task<float> GetCharges(float balance, int accId)
        {
            var charge = _service.GetServiceCharges(balance, accId);
            return charge;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.BLL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace DrinkStore.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly ILinksService _linksService;

        public RootController(ILinksService linksService)
        {
            _linksService = linksService;
        }

        [HttpGet(Name = nameof(Get))]
        public DTO Get()
        {
            var root = new DTO();
            _linksService.AddLinksAsync(root);
            return root;
        }
    }
}
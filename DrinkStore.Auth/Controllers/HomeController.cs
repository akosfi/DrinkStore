using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrinkStore.Auth.Controllers
{
    public class HomeController : Controller
    {
		private readonly IHostingEnvironment _environment;
		private readonly ILogger<HomeController> _logger;
		private readonly IIdentityServerInteractionService _interaction;

		public HomeController(IHostingEnvironment environment, ILogger<HomeController> logger, IIdentityServerInteractionService interaction)
		{
			_environment = environment;
			_logger = logger;
			_interaction = interaction;
		}
		public async Task<IActionResult> Error(string errorId)
		{
			var message = await _interaction.GetErrorContextAsync(errorId);
			
			return Ok(message);
		}
	}
}
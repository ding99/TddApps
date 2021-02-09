using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primes.Lib.Services;

namespace Primes.API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ManiputeStringsController : ControllerBase {

		public ManiputeStringsController(IManipulateStrings service) {

		}

		[HttpPost("reversion/{words}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> ReverseWords(string words) {
			return await Task.Run(() => Ok());
		}
	}
}

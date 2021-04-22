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

		private readonly IManipulateStrings _service;

		public ManiputeStringsController(IManipulateStrings service) {
			_service = service;
		}

		[HttpPost("reversion/{words}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> ReverseWords(string words) {
			try {
				return Ok(await _service.ReverseWords(words));
			}
			catch(Exception e) {
				return StatusCode(500, e);
			}
//			return await Task.Run(() => Ok());
		}
	}
}

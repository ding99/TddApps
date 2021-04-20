using Microsoft.AspNetCore.Mvc;
using Primes.Lib.Services;
using System;
using System.Threading.Tasks;

namespace Primes.API.Controllers {
	[Route("api/primenumbers")]
	[ApiController]
	public class PrimeNumbersController : ControllerBase {

		private readonly IPrimeNumbers _service;
		public PrimeNumbersController(IPrimeNumbers service) {
			_service = service;
		}

		[HttpPost("{number}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> IsPrimeNumber(int number) {
			//return Ok(await Task.Run(() => true));
			try {
				return Ok(await _service.IsPrimeNumber(number));
			}
			catch (Exception e) {
				return StatusCode(500, e);
			}
		}

		[HttpGet("{number}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> FirstPrimeNumbers(int number) {
			//return Ok(await Task.Run(() => new int[0]));
			try {
				return number < 0 ? StatusCode(400, new int[0])
					: Ok(await _service.FirstPrimeNumbers(number));
			}
			catch (Exception e) {
				return StatusCode(500, e);
			}
		}
	}
}

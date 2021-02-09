using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Primes.Lib.Services;

namespace Primes.API.Controllers {
	[Route("api/primenumbers")]
	[ApiController]
	public class PrimeNumbersController : ControllerBase {
		public PrimeNumbersController(IPrimeNumbers service) {

		}

		[HttpPost("{number}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> IsPrimeNumber(int number) {
			return await Task.Run(() => Ok());
		}

		[HttpGet("{number}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> FirstPrimeNumbers(int number) {
			return await Task.Run(() => Ok());
		}
	}
}

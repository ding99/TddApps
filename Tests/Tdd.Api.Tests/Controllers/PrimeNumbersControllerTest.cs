using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Primes.API.Controllers;
using Primes.Lib.Services;
using System.Threading.Tasks;

namespace Tdd.Api.Tests.Controllers {
	public class PrimeNumbersControllerTests {
		private readonly Mock<IPrimeNumbers> _mock;
		private readonly PrimeNumbersController _controller;

		public PrimeNumbersControllerTests() {
			_mock = new Mock<IPrimeNumbers>();
			_controller = new PrimeNumbersController(_mock.Object);
		}

		[TestCase(2)]
		[TestCase(7)]
		[TestCase(17)]
		[TestCase(199)]
		[TestCase(10061)]
		public async Task TestIsPrimeNumber_Happy_True(int number) {
			_mock.Setup(p => p.IsPrimeNumber(number)).Returns(Task.FromResult(true));

			var result = (ObjectResult)await _controller.IsPrimeNumber(number);

			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
			Assert.AreEqual(true, result.Value);
		}

		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(99)]
		[TestCase(10011)]
		public async Task TestIsPrimeNumber_Happy_False(int number) {
			_mock.Setup(p => p.IsPrimeNumber(number)).Returns(Task.FromResult(false));

			var result = (ObjectResult)await _controller.IsPrimeNumber(number);

			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
			Assert.AreEqual(false, result.Value);
		}

		//TODO
	}
}
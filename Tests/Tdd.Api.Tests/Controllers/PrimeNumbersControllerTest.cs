using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Primes.API.Controllers;
using Primes.Lib.Services;
using System.Threading.Tasks;
using System;

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

		[TestCase(-5)]
		public async Task TestIsPrimeNumber_Exception(int number) {
			_mock.Setup(p => p.IsPrimeNumber(It.IsAny<int>())).Throws<Exception>();

			var result = (ObjectResult)await _controller.IsPrimeNumber(number);

			Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
		}

		[TestCase(0, new int[0])]
		[TestCase(1, new int[] { 2 })]
		[TestCase(3, new int[] { 2,3,5 })]
		[TestCase(5, new int[] { 2,3,5,7,11 })]
		[TestCase(8, new int[] { 2,3,5,7,11,13,17,19 })]
		public async Task TestFirstPrimeNumbers_Happy(int value, int[] expected) {
			_mock.Setup(p => p.FirstPrimeNumbers(value)).Returns(Task.FromResult(expected));

			var result = (ObjectResult)await _controller.FirstPrimeNumbers(value);

			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
			Assert.AreEqual(expected, result.Value);
		}

		[TestCase(-1)]
		[TestCase(-2)]
		[TestCase(-3)]
		[TestCase(-4)]
		[TestCase(null)]
		public async Task TestFirstPrimeNumbers_Bad(int value) {
			int[] expectedValue = new int[] { -1 };

			_mock.Setup(p => p.FirstPrimeNumbers(value)).Returns(Task.FromResult(expectedValue));

			var result = (ObjectResult)await _controller.FirstPrimeNumbers(value);

			Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
			Assert.AreEqual(expectedValue, result.Value);
		}


		[TestCase(null)]
		public async Task TestFirstPrimeNumbers_Exception(int value) {
			string expectedMessage = "Invalid input";

			_mock.Setup(p => p.FirstPrimeNumbers(It.IsAny<int>())).Throws<Exception>();

			var result = (ObjectResult)await _controller.FirstPrimeNumbers(value);

			Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
		}
	}
}
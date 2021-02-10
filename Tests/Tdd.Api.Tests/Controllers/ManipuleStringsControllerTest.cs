using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Primes.API.Controllers;
using Primes.Lib.Services;
using System;
using System.Threading.Tasks;

namespace Tdd.Api.Tests.Controllers {
	public class ManipulateStringsControllerTests {
		private readonly Mock<IManipulateStrings> _mock;
		private readonly ManiputeStringsController _controller;

		public ManipulateStringsControllerTests() {
			_mock = new Mock<IManipulateStrings>();
			_controller = new ManiputeStringsController(_mock.Object);
		}

		[TestCase("", "")]
		[TestCase("abc def","def abc")]
		[TestCase("The variable 'expectedMessage' is assigned but its value is never use", "use never is value its but assigned is 'expectedMessage' variable The")]
		[TestCase("55 x 30 = 1650", "1650 = 30 x 55")]
		[TestCase("#_$%", "#_$%")]
		public async Task TestReverseWords_Happy(string source, string expected) {
			_mock.Setup(p => p.ReverseWords(source)).Returns(Task.FromResult(expected));

			var result = (ObjectResult)await _controller.ReverseWords(source);

			Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
			Assert.AreEqual(expected, result.Value);
		}

		[TestCase("abfad-d")]
		public async Task TestReverseWords_Bad(string source) {
			_mock.Setup(p => p.ReverseWords(It.IsAny<string>())).Throws<Exception>();

			var result = (ObjectResult)await _controller.ReverseWords(source);

			Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
		}
	}
}

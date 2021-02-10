using NUnit.Framework;
using Primes.Lib.Concrete;
using System.Threading.Tasks;

namespace Tdd.Lib.Tests.Services {
	class ManipulateStringsServicesTest {
		private readonly ManipulateStrings _operator;

		public ManipulateStringsServicesTest() {
			_operator = new ManipulateStrings();
		}

		[TestCase("", "")]
		[TestCase("abc def", "def abc")]
		[TestCase("The variable 'expectedMessage' is assigned but its value is never use", "use never is value its but assigned is 'expectedMessage' variable The")]
		[TestCase("55 x 30 = 1650", "1650 = 30 x 55")]
		[TestCase("#_$%", "#_$%")]
		public async Task TestReserveWords_Happy(string source, string expected) {
			string result = await _operator.ReverseWords(source);
			Assert.AreEqual(expected, result);
		}

		[TestCase(null)]
		public async Task TestReserveWords_Bad(string source) {
			string expected = string.Empty;

			string result = await _operator.ReverseWords(source);

			Assert.AreEqual(expected, result);
		}
	}
}

using Moq;
using NUnit.Framework;
using Primes.Lib.Services;
using Primes.Lib.Concrete;
using System;
using System.Threading.Tasks;

namespace Tdd.Lib.Tests.Services {
	public class PrimeNumbersServicesTests {
		private readonly PrimeNumbers _operator;

		public PrimeNumbersServicesTests() {
			_operator = new PrimeNumbers();
		}

		[TestCase(2)]
		[TestCase(3)]
		[TestCase(19)]
		[TestCase(199)]
		[TestCase(10061)]
		public async Task TestIsPrime_Happy(int value) {
			var result = await _operator.IsPrimeNumber(value);
			Assert.IsTrue(result);
		}

		[TestCase(1)]
		[TestCase(6)]
		[TestCase(39)]
		[TestCase(201)]
		[TestCase(10062)]
		public async Task TestIsPrime_Bad(int value) {
			var result = await _operator.IsPrimeNumber(value);
			Assert.IsFalse(result);
		}
	}
}
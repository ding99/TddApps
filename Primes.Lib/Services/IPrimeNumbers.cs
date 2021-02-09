using System.Threading.Tasks;

namespace Primes.Lib.Services {
	public interface IPrimeNumbers {
		Task<bool> IsPrimeNumber(int number);
		Task<int[]> FirstPrimeNumbers(int number);
	}
}

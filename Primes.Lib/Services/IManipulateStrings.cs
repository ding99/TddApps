using System.Threading.Tasks;

namespace Primes.Lib.Services {
	public interface IManipulateStrings {
		Task<string> ReverseWords(string words);
	}
}

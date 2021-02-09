using System.Threading.Tasks;

namespace Primes.Lib {
	public interface IManipulateStrings {
		Task<string> ReverseWords(string words);
	}
}

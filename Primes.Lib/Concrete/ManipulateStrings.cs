using System;
using System.Linq;
using System.Threading.Tasks;
using Primes.Lib.Services;

namespace Primes.Lib.Concrete {
	public class ManipulateStrings : IManipulateStrings {
        string Inversion(string words) {
            return string.Join(" ", Enumerable.Reverse(words.Split(' ').ToList()).ToArray());
        }

        public async Task<string> ReverseWords(string words) {
            try {
                return await Task.Run(() => Inversion(words));
            }
            catch (Exception) {
                return string.Empty;
            }
        }
    }
}

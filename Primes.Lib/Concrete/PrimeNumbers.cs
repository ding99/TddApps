using Primes.Lib.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Primes.Lib.Concrete {
	public class PrimeNumbers : IPrimeNumbers {

        bool IsPrime(int number) {
            bool result = number > 1;

            if (number > 2) {
                int upper = number, mid;

                for (int i = 2; i < upper; i++)
                    if ((number % i) == 0) {
                        result = false;
                        break;
                    } else if (upper > (mid = number / i + 1))
                        upper = mid;
            }

            return result;
        }

        public async Task<bool> IsPrimeNumber(int number) {
            return await Task.Run(() => IsPrime(number));
        }

        public async Task<int[]> FirstPrimeNumbers(int count) {
            List<int> lists = new List<int>();

            if (count > 0) {
                for (int i = 0; i < Int32.MaxValue; i++) {
                    if (await IsPrimeNumber(i)) {
                        lists.Add(i);
                        if (lists.Count == count)
                            break;
                    }
                }

                if (lists.Count < count) {
                    lists.Clear();
                    lists.Add(-1);
                }
            }

            return lists.ToArray();
        }
    }
}

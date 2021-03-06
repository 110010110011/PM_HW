using System;

namespace Hw1.Exercise1
{
    /// <summary>
    /// Prime numbers application core.
    /// </summary>
    public class PrimeNumbersApplication
    {
        /// <summary>
        /// Runs prime numbers application.
        /// Prints prime numbers in the given range (from <paramref name="args"/>) to the output.
        /// </summary>
        /// <param name="args">
        /// Arguments - valid integer range [from, to] 
        /// between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>
        /// to find prime numbers.
        /// </param>
        /// <returns>Return <c>0</c> in case of success and <c>-1</c> in case of failure.</returns>
        public int Run(string[] args)
        {
            int firstNum, secondNum;
            if (args is not null && int.TryParse(args[0], out firstNum) && int.TryParse(args[1], out secondNum))
            {
                var min = firstNum < secondNum ? firstNum : secondNum;
                var max = firstNum < secondNum ? secondNum : firstNum;

                for (int i = min; i <= max; i++)
                {
                    var isPrime = true;

                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }

                    }
                    if (isPrime && i > 1)
                    {
                        Console.Write(i + ";");
                    }
                }
                return 0;
            }
            return -1;
        }
    }
}

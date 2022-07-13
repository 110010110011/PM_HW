using System;
using System.Globalization;

namespace Hw1.Exercise5
{
    /// <summary>
    /// Calc application core.
    /// </summary>
    public class CalcApplication
    {
        /// <summary>
        /// Runs calc application.
        /// Prints calculation result.
        /// </summary>
        /// <param name="args"> Math expression.</param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid format of <paramref name="args"/>;
        /// <c>-2</c> in case of invalid math expression <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args is null)
            {
                return -1;
            }


            var input = string.Concat(args).Replace(',', '.');
            string buf1 = "", buf2 = "";
            double op1 = 0, op2 = 0;
            long factorial = 1;
            var sign = ' ';
            var isEcho = true;

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] is '+' or '-' or '*' or 'x' or 'X' or '^' or '/' or '\\' or '!')
                {
                    // find the first operand
                    isEcho = false;
                    for (var j = 0; j < i; j++)
                    {
                        buf1 += input[j];
                    }
                    var op1Parsible = double.TryParse(buf1, NumberStyles.Any, CultureInfo.InvariantCulture, out op1);

                    if (!op1Parsible)
                        return -1;

                    // find the operator
                    sign = input[i];

                    // if factorial is introduced
                    if (sign == '!')
                    {
                        var op1Integer = op1 - (long)op1;

                        if (op1 is >= 0 and <= 18 && op1Integer == 0.0)
                        {
                            for (var n = 1; n <= op1; n++)
                            {
                                factorial *= n;
                            }
                            Console.Write(factorial);
                            return 0;
                        }
                        return -2;
                    }

                    // find second operand 
                    for (var j = i + 1; j < input.Length; j++)
                    {
                        buf2 += input[j];
                    }
                    var op2Parsible = double.TryParse(buf2, NumberStyles.Any, CultureInfo.InvariantCulture, out op2);
                    if (!op2Parsible)
                        return -1;
                    break;
                }
            }

            if (isEcho)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    buf1 += input[i];
                }
                var op1Parsible = double.TryParse(buf1, NumberStyles.Any, CultureInfo.InvariantCulture, out op1);
                if (!op1Parsible)
                    return -1;
                Console.WriteLine(op1);
                return 0;
            }

            switch (sign)
            {
                case '+':
                    Console.Write(op1 + op2);
                    return 0;

                case '-':
                    Console.WriteLine(op1 - op2);
                    return 0;

                case '*':
                case 'x':
                case 'X':
                    Console.WriteLine(op1 * op2);
                    return 0;

                case '^':
                    if (op1 < 0 && op2 is > 0 and < 1)
                    {
                        return -2;
                    }
                    else
                    {
                        Console.WriteLine(Math.Pow(op1, op2));
                        return 0;
                    }

                case '/':
                case '\\':
                    if (op2 != 0)
                    {
                        Console.WriteLine(op1 / op2);
                        return 0;
                    }
                    else
                    {
                        return -2;
                    }

            }
            return -1;
        }
    }
}

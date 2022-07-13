using System;

namespace Hw1.Exercise4
{
    /// <summary>
    /// Array statistics application core.
    /// </summary>
    public class ArrayStatApplication
    {
        /// <summary>
        /// Runs array statistics application.
        /// Prints statistics.
        /// </summary>
        /// <param name="args">
        /// Arguments - integer array.
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args is not null)
            {
                var array = new int[args.Length];
                var sum = 0;
                for (var i = 0; i < args.Length; i++)
                {
                    var parsibleNewElement = int.TryParse(args[i], out var newElement);
                    if (!parsibleNewElement)
                    {
                        return -1;
                    }
                    array[i] = newElement;
                    sum += array[i];
                }

                for (var i = 0; i < array.Length; i++)
                {
                    for (var j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            var buffer = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = buffer;
                        }
                    }
                }

                var minElement = array[0];
                var maxElement = array[array.Length - 1];
                var count = array.Length;

                var average = sum / (double)count;

                Console.WriteLine("Min=" +  minElement);
                Console.WriteLine("Max=" + maxElement);
                Console.WriteLine("Sum=" + sum);
                Console.WriteLine("Average=" + average);
                Console.WriteLine("Count=" + count);
                Console.Write("Sorted=");
                foreach (var item in array) Console.Write(item + ";");
                return 0;
            }
            return -1;
        }
    }
}

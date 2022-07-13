using System;
using System.Globalization;

namespace Hw1.Exercise2
{
    /// <summary>
    /// Area calc application core.
    /// </summary>
    public class AreaCalcApplication
    {
        /// <summary>
        /// Runs area calc application.
        /// Prints area of selected shape (from <paramref name="args"/>) to the output.
        /// </summary>
        /// <param name="args">
        /// Arguments - shape with dimensions.
        /// args[0] - shape [Circle, Square, Rect, Triangle].
        /// args[0..2] - shape dimensions.
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>;
        /// <c>-2</c> in case of invalid dimensions.
        /// </returns>
        public int Run(string[] args)
        {
            if (args is not null && args.Length > 1)
            {
                var figure = args[0].ToLower();
                double dimension;

                for (var i = 1; i < args.Length; i++)
                {
                    args[i] = args[i].Replace(',', '.');
                    var parsibleDimensions = double.TryParse(args[i], NumberStyles.Any, CultureInfo.InvariantCulture, out dimension);

                    if (!parsibleDimensions)
                        return -1;

                    if (dimension <= 0)
                        return -2;
                }

                switch (figure)
                {
                    case "circle":
                        var radius = double.Parse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                        Console.WriteLine(Math.PI * Math.Pow(radius, 2));
                        return 0;

                    case "square":
                        var sideSquare = double.Parse(args[1]);
                        Console.WriteLine(Math.Pow(sideSquare, 2));
                        return 0;

                    case "rect":
                        if (args.Length != 3)
                            return -1;
                        var sideRect1 = double.Parse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                        var sideRect2 = double.Parse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture);
                        Console.WriteLine(sideRect1 * sideRect2);
                        return 0;

                    case "triangle":
                        if (args.Length == 2 )
                        {
                            var sideTriangle1 = double.Parse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                            Console.WriteLine((Math.Sqrt(3) * Math.Pow(sideTriangle1, 2)) / 4);
                        }
                        else if (args.Length == 3)
                        {
                            var sideTriangle1 = double.Parse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                            var sideTriangle2 = double.Parse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture);
                            Console.WriteLine((sideTriangle1 * sideTriangle2) / 2);

                        }
                        else if (args.Length == 4)
                        {
                            var sideTriangle1 = double.Parse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                            var sideTriangle2 = double.Parse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture);
                            var sideTriangle3 = double.Parse(args[3], NumberStyles.Any, CultureInfo.InvariantCulture);
                            if (((sideTriangle1 + sideTriangle2) <= sideTriangle3) || ((sideTriangle1 + sideTriangle3) <= sideTriangle2) || ((sideTriangle2 + sideTriangle3) <= sideTriangle1))
                            {
                                return -2;
                            }
                            var p = (sideTriangle1 + sideTriangle2 + sideTriangle3) / 2; //Half perimeter
                            Console.WriteLine(Math.Sqrt(p * (p - sideTriangle1) * (p - sideTriangle2) * (p - sideTriangle3)));

                        }
                        return 0;
                }
            }
            return -1;

        }
    }
}

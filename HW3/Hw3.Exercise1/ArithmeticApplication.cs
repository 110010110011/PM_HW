namespace Hw3.Exercise1
{
    public sealed class ArithmeticApplication
    {
        private List<int> _parsedList = new();
        /// <summary>
        /// Arithmetic application return codes.
        /// </summary>
        public enum ReturnCode
        {
            Success = 0,
            InvalidArgs = -1,
            Exception = -2
        }

        public ReturnCode Run(string[] args)
        {
            try
            {
                if (IsValidNumbers(args))
                    return ReturnCode.InvalidArgs;

                _parsedList = args.Select(int.Parse).ToList();

                if (IsValidNumberRange(_parsedList))
                    return ReturnCode.Exception;

                var result = ArithmeticProcessor.Calculate(_parsedList);
                Console.WriteLine(string.Join(" ", result));
                return ReturnCode.Success;
            }
            catch (Exception)
            {
                return ReturnCode.Exception;
            }
        }

        private static bool IsValidNumbers(string[] args)
        {
            return args is null ||
                   args.Any(x => x == string.Empty) ||
                   args.Any(x => int.TryParse(x, out var resultInt) == false) ||
                   args.Length == 0;
        }

        private static bool IsValidNumberRange(List<int> numList)
        {
            return numList.Any(
                x => (x > int.MaxValue / 2 && numList.IndexOf(x) % 2 == 0) ||
                     (x < int.MinValue + 10 && numList.IndexOf(x) != 0));
        }
    }
}

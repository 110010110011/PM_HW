namespace Hw3.Exercise1
{
    public static class ArithmeticProcessor
    {
        /// <summary>
        /// Calculates numbers by algorithm.
        /// </summary>
        /// <param name="numbers">Collection of numbers.</param>
        /// <returns>
        /// Returns <c>IEnumerable</c> of sorted numbers. 
        /// </returns>
        /// <exception cref="ArgumentNullException">Sequence is null.</exception>

        public static IEnumerable<int> Calculate(List<int> numbers)
        {
            if (numbers is null)
                throw new ArgumentNullException(nameof(numbers));

            var resultCollection = numbers.Select(
                    (element, index) => index % 2 == 0 ? element * 2 : element - 10).ToList();

            return resultCollection.OrderBy(i => i).Distinct();
        }
    }
}

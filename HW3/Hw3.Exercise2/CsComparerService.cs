using Hw3.Exercise2.Models;

namespace Hw3.Exercise2
{
    public static class CsComparerService
    {
        private static readonly List<PlayerInfo> _players = CsComparerData.Players;
        /// <summary>
        /// Sort players by comparer.
        /// </summary>
        /// <param name="comparer">Comparer that will be using.</param>
        /// <returns>
        /// Returns <c>IEnumerable</c> of sorted players. 
        /// </returns>
        /// <exception cref="ArgumentNullException">Comparer is null.</exception>
        public static IEnumerable<PlayerInfo> Compare(IComparer<PlayerInfo> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            _players.Sort(comparer);
            return _players;
        }
    }
}

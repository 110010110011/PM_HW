using Hw3.Exercise2.Models;

namespace Hw3.Exercise2.Comparers
{
    public class LastNameComparer : IComparer<PlayerInfo>
    {
        public int Compare(PlayerInfo? x, PlayerInfo? y)
        {
            if (x is null || y is null)
                throw new ArgumentNullException(nameof(Compare));

            return string.CompareOrdinal(y.LastName, x.LastName);
        }
    }
}

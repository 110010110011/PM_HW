using Hw3.Exercise2.Comparers;
using Hw3.Exercise2.Models;

namespace Hw3.Exercise2
{
    public sealed class CsComparerApplication
    {
        private static readonly Dictionary<string, IComparer<PlayerInfo>> _sortValues = new()
        {
            { "age", new AgeComparer() },
            { "lastname", new LastNameComparer() },
            { "rank", new PlayerRankComparer() }
        };

        /// <summary>
        /// CsCompare application return codes.
        /// </summary>
        public enum ReturnCode
        {
            Success = 0,
            InvalidArgs = -1
        }

        public ReturnCode Run(string[] args)
        {
            // TODO: Parse and validate the arguments and return result of the command.
            if (args is null || args.Length == 0)
                return ReturnCode.InvalidArgs;

            var sortValue = _sortValues.FirstOrDefault(
                x => x.Key == args[0].ToLower()).Value;
            if (sortValue == null)
                return ReturnCode.InvalidArgs;

            var players = CsComparerService.Compare(sortValue);
            Console.WriteLine(string.Join("\n", players));

            return ReturnCode.Success;
        }
    }
}

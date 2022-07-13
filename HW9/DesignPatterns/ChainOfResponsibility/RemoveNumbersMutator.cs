using System.Text.RegularExpressions;

namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : IStringMutator
    {
        private IStringMutator? _next;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return next;
        }

        public string Mutate(string str)
        {
            if (str is null)
                throw new ArgumentNullException();

            str = Regex.Replace(str, @"[\d]", string.Empty);

            if (_next is not null)
                str = _next.Mutate(str);

            return str;
        }
    }
}

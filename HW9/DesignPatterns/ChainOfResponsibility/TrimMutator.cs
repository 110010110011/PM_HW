namespace DesignPatterns.ChainOfResponsibility
{
    public class TrimMutator : IStringMutator
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

            str = str.Trim();

            if (_next is not null)
                str = _next.Mutate(str);

            return str;
        }
    }
}

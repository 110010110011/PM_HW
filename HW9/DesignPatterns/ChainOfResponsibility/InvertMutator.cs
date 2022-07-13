namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : IStringMutator
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

            str = Reverse(str);

            if (_next is not null)
                str = _next.Mutate(str);

            return str;
        }

        private string Reverse(string str)
        {
            var result = new char[str.Length];
            var index = 0;
            for (var i = str.Length - 1; i >= 0; i--)
            {
                result[i] = str[index];
                index++;
            }

            var st = new string(result);

            if (st is null)
                throw new ArgumentNullException();

            return st;
        }
    }
}

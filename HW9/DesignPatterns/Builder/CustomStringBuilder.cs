namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private char[] _chars;

        private int _length;

        public CustomStringBuilder()
        {
            _chars = new char[100];
        }

        public CustomStringBuilder(string text)
        {
            _chars = text.ToCharArray();
            _length = text.Length;
        }

        public ICustomStringBuilder Append(string str)
        {
            var arrayEmpties = _chars.Length - _length;
            if (arrayEmpties < str.Length)
            {
                Array.Resize(ref _chars, str.Length - arrayEmpties + _chars.Length);
            }

            str.CopyTo(0, _chars, _length, str.Length);
            _length += str.Length;
            return this;
        }

        public ICustomStringBuilder Append(char ch)
        {
            if ((_chars.Length - _length) < 1)
            {
                Array.Resize(ref _chars, _chars.Length + 1);
            }

            _chars[_length] = ch;
            _length++;
            return this;
        }

        public ICustomStringBuilder AppendLine()
        {
            return Append("\n");
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            Append(str);
            return Append("\n");
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            Append(ch);
            return Append("\n");
        }

        public string Build()
        {
            return new string(_chars, 0, _length);
        }
    }
}

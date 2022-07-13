using System.Collections;

namespace Hw3.Exercise3
{
    class MyAwesomeListEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _list;
        private int _position = -1;
        public MyAwesomeListEnumerator(T[] list)
        {
            _list = list;
        }

        public T Current => _position == -1 || _position >= _list.Length ?
                            throw new ArgumentException() :
                            _list[_position];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_position >= _list.Length - 1)
                return false;
            _position++;
            return true;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}

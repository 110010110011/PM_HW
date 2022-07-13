
namespace Hw3.Exercise3
{
    public class MyAwesomeList<T>
    {
        private T[] _list;
        public int Count { get; private set; }

        public MyAwesomeList(int capacity = 1)
        {
            _list = new T[capacity];
        }
        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public T GetByIndex(int index)
        {
            return _list[index];
        }

        public void DeleteByIndex(int index)
        {
            if (Count <= 0)
                return;
            _list = _list.Where((_, elementIndex) => elementIndex != index).ToArray();
            Count--;
        }

        public bool DeleteAllElements()
        {
            try
            {
                _list = Array.Empty<T>();
                Count = 0;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Add(T element)
        {
            Array.Resize(ref _list, Count + 1);
            _list[^1] = element;
            Count++;
        }

        public void InsertAt(T element, int index)
        {
            Array.Resize(ref _list, Count + 1);
            for (var i = _list.Length - 1; i > index; i--)
            {
                _list[i] = _list[i - 1];
            }
            _list[index] = element;

            Count++;
        }

        public bool Contains(T value)
        {
            foreach (var element in _list)
            {
                if (element is not null && element.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyAwesomeListEnumerator<T>(_list);
        }
    }
}

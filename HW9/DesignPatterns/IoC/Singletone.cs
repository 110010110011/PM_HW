namespace DesignPatterns.IoC
{
    public class Singleton<T> where T : class, new()
    {
        private static T? _instance;
        private static readonly object _initLock = new object();

        public T GetInstance()
        {
            if (_instance == null)
                _instance = CreateInstance();

            return _instance;
        }

        private static T CreateInstance()
        {
            lock (_initLock)
            {
                var ctors = typeof(T).GetConstructors();
                return ctors.Length > 0 ?
                    throw new InvalidOperationException() :
                    Activator.CreateInstance<T>();
            }
        }
    }
}

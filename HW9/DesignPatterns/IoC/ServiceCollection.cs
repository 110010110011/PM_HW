using System;

namespace DesignPatterns.IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private ServiceType _serviceType;

        public ServiceCollection(ServiceType serviceType)
        {
            _serviceType = serviceType;
        }

        public ServiceCollection() { }

        public IServiceCollection AddTransient<T>()
        {
            return new ServiceCollection(ServiceType.Transient);
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            return new ServiceCollection(ServiceType.Transient);
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            return new ServiceCollection(ServiceType.Transient);
        }

        public IServiceCollection AddSingleton<T>()
        {
            return new ServiceCollection(ServiceType.Singletone);
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            return new ServiceCollection(ServiceType.Singletone);
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            return new ServiceCollection(ServiceType.Singletone);
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            return new ServiceCollection(ServiceType.Singletone);
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_serviceType);
        }
    }
}

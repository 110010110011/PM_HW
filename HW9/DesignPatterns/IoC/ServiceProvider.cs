using System;

namespace DesignPatterns.IoC
{
    public class ServiceProvider : IServiceProvider
    {
        private readonly ServiceType _serviceType;
        public ServiceProvider(ServiceType serviceType)
        {
            _serviceType = serviceType;
        }

        public T GetService<T>()
        { 
            if (_serviceType is ServiceType.Singletone)
            {
                return Activator.CreateInstance<T>();
            }

            return Activator.CreateInstance<T>();

        }
    }
}

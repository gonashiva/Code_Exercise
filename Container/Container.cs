using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _container = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsInterface || !interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException($"Invalid binding: The implementationType must implement the interfaceType or use the one that implements as the type is {implementationType.Name}");
            }

            _container[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            if (_container.TryGetValue(typeof(T), out Type implementationType))
            {
                return (T)Activator.CreateInstance(implementationType);
            }

            throw new InvalidOperationException($"No binding registered for {typeof(T).Name}");
        }
    }
}
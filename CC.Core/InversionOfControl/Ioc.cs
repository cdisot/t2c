using System;
using System.Collections.Generic;
using System.Linq;
using CC.Core.Exceptions;
using Microsoft.Practices.Unity;

namespace CC.Core.InversionOfControl
{
    public static class Ioc
    {
        private static IUnityContainer _container;

        private static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                    throw new Exception("No ha sido cargado la configuracio de IOC todavia no puedo resolver");
                return _container;
            }
        }

        public static void InitializeFrom<T>()
            where T : class
        {
            foreach (var constructor in typeof (T).Assembly.DefinedTypes
                .Where(t => t.IsSubclassOf(typeof (IIocConfigurator))).Select(c => c.GetConstructor(Type.EmptyTypes)))
            {
                if (constructor == null) throw new EmptyPublicContructorRequiredException();
                var configurator = constructor.Invoke(null) as IIocConfigurator;
                if (configurator != null) configurator.Configure(Container);
            }
        }
        
        public static TInterface Resolve<TInterface>(bool throwExceptionOnError)
        {
            if (!throwExceptionOnError)
            {
                return (Container.IsRegistered<TInterface>())
                           ? Resolve<TInterface>()
                           : default(TInterface);
            }
            return Resolve<TInterface>();
        }

        public static IEnumerable<TInterface> ResolveAll<TInterface>(bool throwExceptionOnError)
        {
            if (!throwExceptionOnError)
            {
                return (Container.IsRegistered<TInterface>())
                           ? ResolveAll<TInterface>()
                           : default(IEnumerable<TInterface>);
            }
            return ResolveAll<TInterface>();
        }

        public static bool CanResolve(Type baseType)
        {
            return Container.IsRegistered(baseType);
        }

        public static TInterface Resolve<TInterface>()
        {
            return Container.Resolve<TInterface>();
        }

        public static TInterface Resolve<TInterface>(string name)
        {
            return Container.Resolve<TInterface>(name);
        }

        public static IEnumerable<TInterface> ResolveAll<TInterface>()
        {
            return Container.ResolveAll<TInterface>();
        }

        public static object Resolve(Type baseType)
        {
            return Container.Resolve(baseType);
        }

        public static IEnumerable<object> ResolveAll(Type baseType)
        {
            return Container.ResolveAll(baseType);
        }
        
        public static void Reset()
        {
            if (_container == null) return;
            _container.Dispose();
            _container = null;
        }
        
        public static bool IsRegistered<T>()
        {
            return Container.IsRegistered<T>();
        }
    }
}

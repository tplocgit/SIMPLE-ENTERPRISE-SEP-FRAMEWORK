using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.DI
{
    class IoCContainer
    {
        private static readonly Dictionary<Type, object> registered_dependency = new Dictionary<Type, object>();

        public static void SetDependency<TInterface, TModule>()
        {
            SetDependency(typeof(TInterface), typeof(TModule));
        }
        private static void SetDependency(Type interfaceType, Type dependencyType)
        {
            if (!interfaceType.IsAssignableFrom(dependencyType))
            {
                throw new ArgumentException(string.Format("Dependency: {0} không tương thích với dạng Interface: {1} được truyền!", dependencyType, interfaceType));
            }
            if (!(interfaceType.IsInterface || interfaceType.IsClass))
            {
                throw new ArgumentException(string.Format("{0} không phải dạng Interface", interfaceType));
            }
            if (!dependencyType.IsClass)
            {
                throw new ArgumentException(string.Format("{0} không phải dạng Class", dependencyType));
            }
            // Lấy constructor của dependency
            var firstConstructor = dependencyType.GetConstructors()[0];
            object module = null;
            // Nếu dạng constructor cần parameter 
            if (firstConstructor.GetParameters().Any())
            {
                var constructorParameters = firstConstructor.GetParameters(); //db, log, es
                var moduleDependecies = new List<object>();
                foreach (var parameter in constructorParameters)
                {
                    var dependency = GetDependency(parameter.ParameterType);
                    moduleDependecies.Add(dependency);
                }
                module = firstConstructor.Invoke(moduleDependecies.ToArray());
            }
            else
            {
                module = firstConstructor.Invoke(null);
            }
            registered_dependency.Add(interfaceType, module);
        }
        public static T GetDependency<T>()
        {
            return (T)GetDependency(typeof(T));
        }

        private static object GetDependency(Type interfaceType)
        {
            if (registered_dependency.ContainsKey(interfaceType))
            {
                return registered_dependency[interfaceType];
            }
            throw new Exception(string.Format("Dependency: {0} chưa được register!", interfaceType));
        }
    }
}
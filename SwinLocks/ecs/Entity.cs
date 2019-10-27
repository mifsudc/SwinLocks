using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class Entity
    {
        private Dictionary<Type, Component> components;

        public Entity()
            => components = new Dictionary<Type, Component>();

        public T get<T>() where T : Component =>
            components[typeof(T)] as T;

        public bool has<T>() where T : Component =>
            components.ContainsKey(typeof(T));

        public void attach(Component comp)
            => components.Add( comp.GetType(), comp);

        public void detach<T>() where T: Component
            => components.Remove(typeof(T));
    }
}

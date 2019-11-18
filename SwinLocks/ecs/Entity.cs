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
        private List<Subscriber> subscribers;

        public Entity() {
            components = new Dictionary<Type, Component>();
            subscribers = new List<Subscriber>();
        }

        public T get<T>() where T : Component =>
            components[typeof(T)] as T;

        public bool has<T>() where T : Component =>
            components.ContainsKey(typeof(T));

        public void attach(Component comp)
            => components.Add( comp.GetType(), comp);

        public void detach<T>() where T: Component
            => components.Remove(typeof(T));

        public void subscribe(Subscriber s) =>
            subscribers.Add(s);

        public void notify() {
            foreach ( Subscriber s in subscribers )
                s.notify(this);
        }
    }
}

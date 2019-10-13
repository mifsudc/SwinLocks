using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks.ecs
{
    class Entity
    {
        private Dictionary<Type, Component> components;

        public Component Get<T>() where T : Component
        {
            return components[typeof(T)];
        }

        void Attach(Component comp)
        {
            components.Add( comp.GetType(), comp);
        }

        void Log()
        {
            foreach (KeyValuePair<Type, Component> e in components)
            {
                Console.WriteLine(e.Key.ToString() + " " + e.Value.ToString());
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class Entity
    {
        private Dictionary<Type, Component> components;

        public Entity() {
            components = new Dictionary<Type, Component>();
        }

        public Component get<T>() where T : Component =>
            components[typeof(T)];

        public bool has<T>() where T : Component =>
            components.ContainsKey(typeof(T));

        public void attach(Component comp)
        {
            components.Add( comp.GetType(), comp);
        }

        public void log()
        {
            foreach (KeyValuePair<Type, Component> e in components)
            {
                Console.WriteLine(e.Key.ToString() + " " + e.Value.ToString());
            }
        }
    }
}

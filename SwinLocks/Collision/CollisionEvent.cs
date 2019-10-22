using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CollisionEvent {
        public Entity e1;
        public Entity e2;

        public CollisionEvent(Entity e1, Entity e2) {
            this.e1 = e1;
            this.e2 = e2;
        }

        public bool has<T>() where T : Component
            => e1.has<T>() || e2.has<T>();

        public bool has<T, S>() where T : Component where S : Component
            => (e1.has<T>() && e2.has<S>())
            || (e2.has<T>() && e1.has<S>());
    }
}

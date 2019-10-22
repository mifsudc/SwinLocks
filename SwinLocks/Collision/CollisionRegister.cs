using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CollisionRegister {
        private List<CollisionEvent> colls;

        public CollisionRegister()
            => colls = new List<CollisionEvent>();

        private CollisionRegister(List<CollisionEvent> colls)
            => this.colls = colls;

        public void clear()
            => colls.Clear();

        public void register(Entity e1, Entity e2)
            => colls.Add( new CollisionEvent(e1, e2) );

        public CollisionRegister query<T>() where T : Component 
           => new CollisionRegister( colls.Where( e => e.has<T>() ).ToList() );

        public CollisionRegister query<T, S>() where T : Component where S : Component
            => new CollisionRegister( colls.Where(e => e.has<T, S>()).ToList() );
        
        public List<CollisionEvent> toList() =>
            colls;
    }
}

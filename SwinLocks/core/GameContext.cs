using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class GameContext 
    {
        public static GameContext I;
        private List<Entity> entities;
        public CollisionRegister collRegister;

        public GameContext() {
            if (I != null) {
                throw new Exception("There may only be one game context.");
            }
            else {
                I = this;
            }

            entities = new List<Entity>();
            collRegister = new CollisionRegister();
        }

        public static void registerEntity(Entity e)
            => I.entities.Add(e);

        public static void registerEntities(List<Entity> l)
            => I.entities.AddRange(l);

        public static void deregisterEntity(Entity e) {
            e.notify();
            I.entities.Remove(e);
        }

        public static List<Entity> queryEntities<T>() where T : Component
            => (from e in I.entities where e.has<T>() select e).ToList();
    }
}

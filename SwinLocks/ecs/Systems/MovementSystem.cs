using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class MovementSystem : System
    {
        public override void Execute()
        {
            List<Entity> ents = GameContext.I.entities.Where(e => e.has<SpatialComponent>()).ToList();

            foreach (Entity e in ents)
            {
                SpatialComponent s = e.get<SpatialComponent>() as SpatialComponent;

                s.pos += s.vel;
                if (s.friction) {
                    s.vel.X *= Constants.FRICTION;
                    s.vel.Y *= Constants.FRICTION;
                }
            }
        }
    }
}

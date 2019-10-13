using SwinLocks.ecs.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks.ecs.Systems
{
    class MovementSystem : System
    {
        private List<Entity> ents;

        public override void Execute()
        {
            foreach (Entity e in ents)
            {
                SpatialComponent s = e.Get<SpatialComponent>() as SpatialComponent;

                // Apply accel
                s.pos += s.vel;
            }
        }
    }
}

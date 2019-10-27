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
            List<Entity> ents = GameContext.queryEntities<SpatialComponent>();

            foreach (Entity e in ents)
            {
                SpatialComponent s = e.get<SpatialComponent>();

                s.rot += s.angularMomentum;

                s.pos += s.vel;
                if (s.friction) {
                    s.vel.X *= Constants.FRICTION;
                    s.vel.Y *= Constants.FRICTION;
                }

                if ( s.pos.Y - s.origin.Y > Constants.SCREEN_Y )
                    s.pos.Y = 0;
                else if ( s.pos.Y + s.origin.Y < 0 )
                    s.pos.Y = Constants.SCREEN_Y;

                if ( s.pos.X - s.origin.X > Constants.SCREEN_X )
                    s.pos.X = 0;
                else if ( s.pos.X + s.origin.X < 0 )
                    s.pos.X = Constants.SCREEN_X;
            }
        }
    }
}

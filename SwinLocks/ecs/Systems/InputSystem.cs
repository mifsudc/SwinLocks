using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class InputSystem : System {
        public override void Execute() {
            List<Entity> ents = GameContext.I.entities.Where(e => e.has<ControllableComponent>()).ToList();
            foreach (Entity e in ents) {
                ControllableComponent c = e.get<ControllableComponent>() as ControllableComponent;

                List<Command> comms = c.Controller.Poll();

                foreach (Command comm in comms) {
                    SpatialComponent s = e.get<SpatialComponent>() as SpatialComponent;
                    if (comm == Command.Up) {
                        s.vel.X += (float) Math.Cos(s.rot) * Constants.PLAYER_ACCELERATION;
                        s.vel.Y += (float) Math.Sin(s.rot) * Constants.PLAYER_ACCELERATION;
                    }

                    if (comm == Command.Left) {
                        s.rot -= 0.05f;
                        if ( s.rot < 0 ) s.rot += 2 * (float)Math.PI;
                    }

                    if ( comm == Command.Right ) {
                        s.rot += 0.05f;
                        if ( s.rot > 2 * Math.PI ) s.rot -= 2 * (float) Math.PI;
                    }

                    if ( comm == Command.Down ) {
                        s.vel.X *= 0.7f;
                        s.vel.Y *= 0.7f;
                    }

                    if ( comm == Command.Sk1 ) {
                        CollisionComponent coll = e.get<CollisionComponent>() as CollisionComponent;
                        GameContext.I.entities.Add(EntityFactory.fireball(
                            e, s.pos, coll.radius, s.rot) );
                    }
                }
            }
        }
    }
}

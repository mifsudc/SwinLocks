using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace SwinLocks {
    class InputSystem : System {
        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<ControllableComponent>();
            foreach (Entity e in ents) {
                ControllableComponent c = e.get<ControllableComponent>();
                List<Controller.Command> comms = c.controller.Poll();
                foreach ( Controller.Command comm in comms) {
                    SpatialComponent s = e.get<SpatialComponent>();
                    if (comm == Controller.Command.Up) {
                        s.vel.X += (float) Math.Cos(s.rot) * Constants.PLAYER_ACCELERATION;
                        s.vel.Y += (float) Math.Sin(s.rot) * Constants.PLAYER_ACCELERATION;
                    }

                    else if (comm == Controller.Command.Left) {
                        s.rot -= Constants.TURN_RATE;
                        if ( s.rot < 0 ) s.rot += 2 * (float)Math.PI;
                    }

                    else if ( comm == Controller.Command.Right ) {
                        s.rot += Constants.TURN_RATE;
                        if ( s.rot > 2 * Math.PI ) s.rot -= 2 * (float) Math.PI;
                    }

                    else if ( comm == Controller.Command.Down ) {
                        s.vel.X *= 0.95f;
                        s.vel.Y *= 0.95f;
                    }

                    else
                        c.skillProc.Process(comm, e);
                }
            }
        }
    }
}
;
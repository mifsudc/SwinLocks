using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class GravityCommand : Command {
        public override void execute(Entity e, SpatialComponent s) {
            Entity a = EntityFactory.gravity(e, s.pos, s.rot);
            GameContext.registerEntity(a);
            Resources.blink.Play();
        }
    }
}

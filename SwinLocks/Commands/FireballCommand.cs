using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class FireballCommand : Command {
        public override void execute(Entity e, SpatialComponent s)
            => GameContext.registerEntity(EntityFactory.fireball(e, s.pos, s.rot));
    }
}

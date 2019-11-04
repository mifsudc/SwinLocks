using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DrainCommand : Command {
        public override void execute(Entity e, SpatialComponent s) =>
            GameContext.registerEntity( EntityFactory.DrainShot(e, s.pos, s.rot) );
    }
}

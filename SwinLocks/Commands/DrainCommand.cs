using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DrainCommand : Command {
        public override void execute(Entity e, SpatialComponent s) {
            Entity a = EntityFactory.DrainShot(e, s.pos, s.rot);
            a.subscribe(Subscriber.particle);
            GameContext.registerEntity(a);
            Resources.shootFireball.Play();
        }
    }
}

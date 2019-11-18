using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class ParticleSubscriber : Subscriber {
        public override void notify(Entity e) {
            for ( int i = 0; i < 15; i++ ) {
                GameContext.registerEntity(EntityFactory.particle(e.get<SpatialComponent>().pos));
            }
        }
    }
}

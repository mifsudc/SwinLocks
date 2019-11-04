using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace SwinLocks {
    class LavaSystem : System {
        CircleF bounds;
        int clock;
        Entity entity;

        public LavaSystem() {
            bounds = new CircleF(
                new Point2( Constants.SCREEN_X / 2, Constants.SCREEN_Y /2 ),
                Constants.SCREEN_X / 2);
            clock = Constants.LAVA_CLOCK;

        }
        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<HealthComponent>();
            foreach ( Entity e in ents ) {
                if ( !bounds.Contains( e.get<SpatialComponent>().pos ) ) {
                    e.get<HealthComponent>().health -= Constants.LAVA_DAMAGE;
                }
            }
            if (clock-- == 0) {
                // Reduce size
                clock = Constants.LAVA_CLOCK;
            }
        }
    }
}

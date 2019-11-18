using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace SwinLocks {
    class LavaSystem : System {
        public CircleF bounds;
        private int clock;
        private int clockStep;
        private Config config;

        public LavaSystem() {
            bounds = new CircleF(
                new Point2( Constants.SCREEN_X / 2, Constants.SCREEN_Y /2 ),
                Constants.SCREEN_X / 3);
            clock = 0;
            clockStep = Constants.LAVA_CLOCK;
            config = Config.get();
        }
        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<HealthComponent>();
            foreach ( Entity e in ents ) {
                if ( !bounds.Contains( e.get<SpatialComponent>().pos ) ) {
                    e.get<HealthComponent>().health -= config.LAVA_DAMAGE;
                }
            }

            if ( ++clock == clockStep ) {
                --bounds.Radius;
                clock = 0;
            }
        }
    }
}

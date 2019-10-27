using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class AnimationSystem : System {

        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<AnimationComponent>();

            foreach (Entity e in ents) {
                AnimationComponent a = e.get<AnimationComponent>();

                foreach ( (Animations.animate animate, int period) in a.animations )
                    if (a.step % period == 0)
                        animate(e);

                if ( ++a.step == a.majorCycle )
                    a.step = 0;
            }
        }
    }
}

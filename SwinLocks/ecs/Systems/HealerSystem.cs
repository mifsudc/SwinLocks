using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class HealerSystem : System {
        public override void Execute() {
            List<CollisionEvent> colls = GameContext.I.collRegister
                .query<HealerComponent, HealthComponent>().toList();

            foreach ( CollisionEvent c in colls ) {
                Entity e;
                if ( c.e1.has<HealerComponent>() )
                    e = c.e1;
                else
                    e = c.e2;

                HealthComponent t = e.get<OwnableComponent>().owner.get<HealthComponent>();
                HealerComponent h = e.get<HealerComponent>();
                t.health += h.power;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DamageSystem : System {
        public override void Execute() {
            List<CollisionEvent> events = GameContext.I.collRegister
                .query<HealthComponent, DamageComponent>().toList();

            foreach ( CollisionEvent e in events ) {
                if ( (e.e1.has<OwnableComponent>() && e.e1.get<OwnableComponent>().owner == e.e2)
                    || (e.e2.has<OwnableComponent>() && e.e2.get<OwnableComponent>().owner == e.e1) )
                        continue;

                if ( e.e1.has<DamageComponent>() )
                    e.e2.get<HealthComponent>().health -= e.e1.get<DamageComponent>().damage;

                if ( e.e2.has<DamageComponent>() )
                    e.e1.get<HealthComponent>().health -= e.e2.get<DamageComponent>().damage;
            }
        }
    }
}

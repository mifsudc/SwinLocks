using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DecaySystem : System {

        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<DecayComponent>();

            for ( int i = ents.Count - 1; i > -1; i--) {
                DecayComponent d = ents[i].get<DecayComponent>();
                if ( d.ttl == 0 )
                    GameContext.deregisterEntity(ents[i]);
                else
                    d.ttl--;
            }
        }
    }
}

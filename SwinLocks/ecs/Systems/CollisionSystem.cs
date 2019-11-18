using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CollisionSystem : System {

        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<CollisionComponent>();
            if ( ents.Count > 1 ) {

                for ( int i = 0; i < ents.Count; i++ ) {
                    for ( int j = i + 1; j < ents.Count; j++ ) {
                        CollisionComponent p1Coll = ents[i].get<CollisionComponent>();
                        SpatialComponent p1Spac = ents[i].get<SpatialComponent>();

                        CollisionComponent p2Coll = ents[j].get<CollisionComponent>();
                        SpatialComponent p2Spac = ents[j].get<SpatialComponent>();

                        // get rid of this
                        if (ents[i].has<OwnableComponent>()) {
                            if ( ents[i].get<OwnableComponent>().owner == ents[j] )
                                continue;
                        }
                        else if ( ents[j].has<OwnableComponent>() ) {
                            if ( ents[j].get<OwnableComponent>().owner == ents[i] )
                                continue;
                        }

                        // Obtain shape collider delegate and check entity intersection
                        if ( Collider.get(p1Coll.Type, p2Coll.Type) (ents[i], ents[j]) )
                            GameContext.I.collRegister.register(ents[i], ents[j]);
                    }
                }
            }
        }
    }
}
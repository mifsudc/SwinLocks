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
                            OwnableComponent p1Own = ents[i].get<OwnableComponent>();
                            if ( p1Own.owner == ents[j] )
                                continue;
                        }
                        else if ( ents[j].has<OwnableComponent>() ) {
                            OwnableComponent p2Own = ents[j].get<OwnableComponent>() as OwnableComponent;
                            if ( p2Own.owner == ents[i] )
                                continue;
                        }

                        // Obtain shape collider delegate and check entity intersection
                        if ( Collider.get(p1Coll.Type, p2Coll.Type) (ents[i], ents[j]) ) {

                            GameContext.I.collRegister.register(ents[i], ents[j]);

                            if ( ents[i].has<BumpComponent>() ) {
                                Vector2 dir = p1Spac.pos - p2Spac.pos;
                                dir.Normalize();
                                p2Spac.vel = Vector2.Multiply( Vector2.Negate(dir), p2Spac.vel.Length() * Constants.BUMP_EFFICIENCY);
                            }

                            if ( ents[j].has<BumpComponent>() ) {
                                Vector2 dir = p2Spac.pos - p1Spac.pos;
                                dir.Normalize();
                                p1Spac.vel = Vector2.Multiply(Vector2.Negate(dir), p1Spac.vel.Length() * Constants.BUMP_EFFICIENCY);
                            }
                        }
                    }
                }
            }
        }
    }
}
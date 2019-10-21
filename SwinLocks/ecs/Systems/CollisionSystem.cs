using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CollisionSystem : System {

        public override void Execute() {
            List<Entity> ents = GameContext.I.entities.Where(e => e.has<CollisionComponent>()).ToList();
            if ( ents.Count > 1 ) {

                foreach ( Entity e in ents ) {
                    (e.get<CollisionComponent>() as CollisionComponent).colliding = false;
                }

                for ( int i = 0; i < ents.Count; i++ ) {
                    for ( int j = i + 1; j < ents.Count; j++ ) {
                        CollisionComponent p1Coll = ents[i].get<CollisionComponent>() as CollisionComponent;
                        SpatialComponent p1Spac = ents[i].get<SpatialComponent>() as SpatialComponent;
                        RenderableComponent p1Ren = ents[i].get<RenderableComponent>() as RenderableComponent;

                        CollisionComponent p2Coll = ents[j].get<CollisionComponent>() as CollisionComponent;
                        SpatialComponent p2Spac = ents[j].get<SpatialComponent>() as SpatialComponent;
                        RenderableComponent p2Ren = ents[j].get<RenderableComponent>() as RenderableComponent;

                        if ( Vector2.Distance(p1Spac.pos + p1Ren.mid, p2Spac.pos + p2Ren.mid)
                            < p1Coll.radius + p2Coll.radius ) {
                            p1Coll.colliding = true;
                            p2Coll.colliding = true;

                            if ( ents[i].has<BumpComponent>() ) {
                                Vector2 dir = p1Spac.pos + p1Ren.mid - (p2Spac.pos + p2Ren.mid);
                                dir.Normalize();
                                p2Spac.vel = Vector2.Multiply( Vector2.Negate(dir), p2Spac.vel.Length() * 0.5f );
                            }

                            if ( ents[j].has<BumpComponent>() ) {
                                Vector2 dir = p2Spac.pos + p2Ren.mid - (p1Spac.pos + p1Ren.mid);
                                dir.Normalize();
                                p1Spac.vel = Vector2.Multiply(Vector2.Negate(dir), p1Spac.vel.Length() * 0.5f);
                            }
                        }
                    }
                }
            }
        }
    }
}
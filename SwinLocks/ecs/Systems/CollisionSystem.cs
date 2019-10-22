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

                //foreach ( Entity e in ents ) {
                //    (e.get<RenderableComponent>() as RenderableComponent).col = Color.LightGray;
                //}

                for ( int i = 0; i < ents.Count; i++ ) {
                    for ( int j = i + 1; j < ents.Count; j++ ) {
                        CollisionComponent p1Coll = ents[i].get<CollisionComponent>() as CollisionComponent;
                        SpatialComponent p1Spac = ents[i].get<SpatialComponent>() as SpatialComponent;
                        RenderableComponent p1Ren = ents[i].get<RenderableComponent>() as RenderableComponent;

                        CollisionComponent p2Coll = ents[j].get<CollisionComponent>() as CollisionComponent;
                        SpatialComponent p2Spac = ents[j].get<SpatialComponent>() as SpatialComponent;
                        RenderableComponent p2Ren = ents[j].get<RenderableComponent>() as RenderableComponent;

                        if (ents[i].has<OwnableComponent>()) {
                            OwnableComponent p1Own = ents[i].get<OwnableComponent>() as OwnableComponent;
                            if ( p1Own.owner == ents[j] )
                                continue;
                        }
                        else if ( ents[j].has<OwnableComponent>() ) {
                            OwnableComponent p2Own = ents[j].get<OwnableComponent>() as OwnableComponent;
                            if ( p2Own.owner == ents[i] )
                                continue;
                        }

                        if ( Vector2.Distance(p1Spac.pos + p1Ren.mid, p2Spac.pos + p2Ren.mid)
                            < p1Coll.radius + p2Coll.radius ) {

                            GameContext.I.collRegister.register(ents[i], ents[j]);

                            if ( ents[i].has<BumpComponent>() ) {

                                Vector2 dir = p1Spac.pos + p1Ren.mid - (p2Spac.pos + p2Ren.mid);
                                dir.Normalize();
                                p2Spac.vel = Vector2.Multiply( Vector2.Negate(dir), p2Spac.vel.Length() * Constants.BUMP_EFFICIENCY);
                            }

                            if ( ents[j].has<BumpComponent>() ) {
                                Vector2 dir = p2Spac.pos + p2Ren.mid - (p1Spac.pos + p1Ren.mid);
                                dir.Normalize();
                                p1Spac.vel = Vector2.Multiply(Vector2.Negate(dir), p1Spac.vel.Length() * Constants.BUMP_EFFICIENCY);
                            }

                            if ( ents[i].has<HealthComponent>() && ents[j].has<DamageComponent>() ) {
                                HealthComponent h = ents[i].get<HealthComponent>() as HealthComponent;
                                DamageComponent d = ents[j].get<DamageComponent>() as DamageComponent;
                                h.health -= d.damage;
                                Console.WriteLine("Took " + d.damage + " damage to " + h.health + " health");
                            }

                            if ( ents[j].has<HealthComponent>() && ents[i].has<DamageComponent>() ) {
                                HealthComponent h = ents[j].get<HealthComponent>() as HealthComponent;
                                DamageComponent d = ents[i].get<DamageComponent>() as DamageComponent;
                                h.health -= d.damage;
                                Console.WriteLine("Took " + d.damage + " damage to " + h.health + " health");
                            }
                        }
                    }
                }
            }
        }
    }
}
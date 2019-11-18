using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class KnockbackSystem : System {
        public override void Execute() {
            List<CollisionEvent> events = GameContext.I.collRegister
                .query<BumpComponent, BumpComponent>().toList();

            foreach ( CollisionEvent e in events ) {

                if ( e.e1.has<BumpComponent>() ) {
                    SpatialComponent e1Spac = e.e1.get<SpatialComponent>();
                    SpatialComponent e2Spac = e.e2.get<SpatialComponent>();
                    Vector2 dir = e1Spac.pos - e2Spac.pos;
                    dir.Normalize();
                    e2Spac.vel = Vector2.Multiply(Vector2.Negate(dir), e2Spac.vel.Length() * Constants.BUMP_EFFICIENCY);
                }

                if ( e.e2.has<BumpComponent>() ) {
                    SpatialComponent e1Spac = e.e1.get<SpatialComponent>();
                    SpatialComponent e2Spac = e.e2.get<SpatialComponent>();
                    Vector2 dir = e2Spac.pos - e1Spac.pos;
                    dir.Normalize();
                    e1Spac.vel = Vector2.Multiply(Vector2.Negate(dir), e1Spac.vel.Length() * Constants.BUMP_EFFICIENCY);
                }
            }

            events = GameContext.I.collRegister
                .query<ImpulseComponent, ImpulsableComponent>().toList();

            foreach ( CollisionEvent e in events ) {

                if ( e.e1.has<ImpulseComponent>() ) {
                    SpatialComponent e1Spac = e.e1.get<SpatialComponent>();
                    SpatialComponent e2Spac = e.e2.get<SpatialComponent>();
                    Vector2 dir = e1Spac.pos - e2Spac.pos;
                    dir.Normalize();
                    e2Spac.vel = Vector2.Multiply(Vector2.Negate(dir), e.e1.get<ImpulseComponent>().power);
                }

                if ( e.e2.has<ImpulseComponent>() ) {
                    SpatialComponent e1Spac = e.e1.get<SpatialComponent>();
                    SpatialComponent e2Spac = e.e2.get<SpatialComponent>();
                    Vector2 dir = e2Spac.pos - e1Spac.pos;
                    dir.Normalize();
                    e1Spac.vel = Vector2.Multiply(Vector2.Negate(dir), e.e2.get<ImpulseComponent>().power);
                }
            }
        }
    }
}

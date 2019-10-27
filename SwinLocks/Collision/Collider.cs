using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    static class Collider {

        public delegate bool collide(Entity e1, Entity e2);

        public static collide get(Type T, Type S) {
            Type rect = typeof(RectHitbox);
            Type circle = typeof(CircleHitbox);

            if ( T == rect && S == rect )
                return rectToRect;

            else if ( T == circle && S == circle )
                return circleToCircle;

            else
                return lineToLine;
        }
        public static bool rectToRect(Entity e1, Entity e2) {
            SpatialComponent e1s = e1.get<SpatialComponent>();
            RectHitbox e1h = e1.get<CollisionComponent>().hitbox as RectHitbox;
            SpatialComponent e2s = e2.get<SpatialComponent>();
            RectHitbox e2h = e2.get<CollisionComponent>().hitbox as RectHitbox;

            return e1h.getBounds(e1s.pos).Intersects(e2h.getBounds(e2s.pos));
        }

        public static bool rectToCircle(Entity e1, Entity e2) {
            RectangleF rect;
            CircleF circ;

            SpatialComponent e1s = e1.get<SpatialComponent>();
            CollisionComponent e1c = e1.get<CollisionComponent>();
            SpatialComponent e2s = e2.get<SpatialComponent>();
            CollisionComponent e2c = e2.get<CollisionComponent>();

            if ( e1c.hitbox.type == typeof(RectHitbox) ) {
                rect = (e1c.hitbox as RectHitbox).getBounds(e1s.pos);
                circ = new CircleF( e2s.pos, (e2c.hitbox as CircleHitbox).radius);
            }
            else {
                rect = (e2c.hitbox as RectHitbox).getBounds(e2s.pos);
                circ = new CircleF(e1s.pos, (e1c.hitbox as CircleHitbox).radius);
            }

            return Shape.Intersects(rect, circ);
        }

        public static bool rectToLine(Entity e1, Entity e2) {
            return true;
        }

        public static bool circleToCircle(Entity e1, Entity e2) {
            SpatialComponent e1s = e1.get<SpatialComponent>();
            CircleHitbox e1h = e1.get<CollisionComponent>().hitbox as CircleHitbox;
            SpatialComponent e2s = e2.get<SpatialComponent>();
            CircleHitbox e2h = e2.get<CollisionComponent>().hitbox as CircleHitbox;

            return Vector2.Distance(e1s.pos, e2s.pos) < e1h.radius + e2h.radius;
        }

        public static bool circleToLine(Entity e1, Entity e2) {
            return true;
        }

        public static bool lineToLine(Entity e1, Entity e2) {
            return true;
        }
    }
}

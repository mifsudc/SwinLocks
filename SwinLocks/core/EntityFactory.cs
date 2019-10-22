using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SwinLocks {
    static class EntityFactory {
        public static Entity player(int offset, IInputController controller = null) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.player, 4, Color.LightGray);
            Rectangle off = new Rectangle(offset % 2 * 100, (int)Math.Floor((double)(offset / 2)) * 100, 100, 100);
            r.offset = off;
            e.attach(r);
            e.attach(new SpatialComponent(300 * offset + 100f, 100f, true));
            e.attach(new CollisionComponent(r.tex.Width / 4));
            e.attach(new BumpComponent());
            e.attach(new HealthComponent(200));
            e.attach(new DestructorComponent());

            if (controller != null) {
                ControllableComponent c = new ControllableComponent();
                c.Controller = controller;
                e.attach(c);
            }

            return e;
        }

        public static Entity pillar(int x, int y) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.pillar, 2, Color.LightGray);
            e.attach(r);
            e.attach(new SpatialComponent(x, y, false));
            e.attach(new CollisionComponent(r.tex.Width / 2));
            e.attach(new BumpComponent());
            e.attach(new DestructorComponent());

            return e;
        }

        public static Entity fireball(Entity owner, Vector2 sourcePos, float sourceRad, float rot) {
            Entity e = new Entity();

            RenderableComponent r = new RenderableComponent(Resources.fireball, 2, Color.Red);
            e.attach(r);
            Vector2 pos = sourcePos;
            SpatialComponent s = new SpatialComponent(pos, false);
            s.vel = Vector2.Multiply(
                new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)), Constants.FIREBALL_SPEED );
            e.attach(s);
            e.attach(new CollisionComponent(r.tex.Width / 2));
            e.attach(new DecayComponent(45));
            e.attach(new DestructibleComponent());
            e.attach(new OwnableComponent(owner));
            e.attach(new DamageComponent(20));

            return e;
        }

        //public static Entity lightning(Entity owner, Vector2 sourcePos, float sourceRadius, float rot) {
        //    Entity e = new Entity();

        //    RenderableComponent r = new RenderableComponent(Resources.lightning, 2, Color.White);
        //    r.offset = new Rectangle(0, 0, 400, 5);
        //    e.attach(r);

        //    float rad = r.tex.Width / 2;
        //    Vector2 pos = sourcePos; /*new Vector2( (float) ( (sourceRad + rad) * Math.Cos(rot) ),
        //        (float) ( (sourceRad + rad) * Math.Sin(rot) ) );*/
        //    SpatialComponent s = new SpatialComponent(pos, false);
        //    e.attach(s);
        //    e.attach(new CollisionComponent(r.tex.Width / 2));
        //    e.attach(new DecayComponent(5));
        //    e.attach(new OwnableComponent(owner));
        //    e.attach(new DamageComponent(20));

        //    return e;
        //}
    }
}

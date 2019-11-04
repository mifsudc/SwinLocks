using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace SwinLocks {
    static class EntityFactory {

        private static FastRandom rand = new FastRandom();

        private static CircleHitbox playerHitbox;
        public static Entity player(int offset, IInputController controller = null) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.player, Color.White);
            r.offset = new Rectangle(0, Constants.PLAYER_PILLAR * offset, Constants.PLAYER_PILLAR, Constants.PLAYER_PILLAR);
            r.drawRotation = false;
            e.attach(r);

            e.attach(new SpatialComponent( (offset + 1) * (Constants.SCREEN_X / 5) , 150f, true,
                new Vector2(Constants.PLAYER_PILLAR / 2, Constants.PLAYER_PILLAR / 2)));
            
            if (playerHitbox == null)
                playerHitbox = new CircleHitbox(Constants.PLAYER_PILLAR / 2);

            e.attach(new CollisionComponent(playerHitbox));
            e.attach(new BumpComponent());
            e.attach(new HealthComponent(60));
            e.attach(new DestructorComponent());

            e.attach(new AnimationComponent(
                new List<(Animations.animate animate, int period)>{
                    (Animations.rotator, 1)
                } ));

            if (controller != null) {
                ControllableComponent c = new ControllableComponent();
                c.Controller = controller;
                e.attach(c);
            }

            return e;
        }

        private static Hitbox pillarHitbox;
        public static Entity pillar(int x, int y) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.pillar, Color.LightGray);
            e.attach(r);

            e.attach( new SpatialComponent(x, y, false,
                new Vector2(Constants.PLAYER_PILLAR / 2, Constants.PLAYER_PILLAR / 2) ));

            if ( pillarHitbox == null )
                pillarHitbox = new CircleHitbox(Constants.PLAYER_PILLAR / 2);

            e.attach( new CollisionComponent(pillarHitbox) );
            e.attach( new BumpComponent() );
            e.attach( new DestructorComponent() );

            return e;
        }

        private static Hitbox fireballHitbox;
        public static Entity fireball(Entity owner, Vector2 sourcePos, float rot) {
            Entity e = new Entity();

            RenderableComponent r = new RenderableComponent(Resources.fireball, Color.Red);
            e.attach(r);

            Vector2 pos = sourcePos;
            SpatialComponent s = new SpatialComponent(pos, false,
                new Vector2( r.tex.Width / 2, r.tex.Height / 2) );
            s.vel = Vector2.Multiply(
                new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)), Constants.FIREBALL_SPEED);
            s.angularMomentum += 0.9f;
            e.attach(s);

            if ( fireballHitbox == null )
                fireballHitbox = new CircleHitbox(r.tex.Height / 2);

            e.attach(new CollisionComponent(fireballHitbox));
            e.attach(new DecayComponent(45));
            e.attach(new DestructibleComponent());
            e.attach(new OwnableComponent(owner));
            e.attach(new DamageComponent(20));

            e.attach( new AnimationComponent( 
                new List<(Animations.animate animate, int period)>{
                    (Animations.rotateColors(
                        new List<Color>() { Color.Orange, Color.Red, Color.Crimson }
                        ), 2)
                } 
            ));

            return e;
        }

        public static Entity particle(Vector2 sourcePos) {
            Entity e = new Entity();

            RenderableComponent r = new RenderableComponent(Resources.particle,
                new Color(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255) ) );
            e.attach(r);

            SpatialComponent s = new SpatialComponent(sourcePos, true,
                new Vector2(r.tex.Width / 2, r.tex.Height / 2) );
            float rot = rand.NextSingle( 2 * (float)Math.PI );
            float mag = rand.NextSingle(2f, 8f);
            s.vel = ExtensionMethods.polarVector(mag, rot);
            e.attach(s);

            e.attach(new DecayComponent(8));

            return e;
        }

        public static Entity DrainShot(Entity owner, Vector2 sourcePos, float rot) {
            Entity e = new Entity();

            RenderableComponent r = new RenderableComponent(Resources.fireball, Color.Green);
            e.attach(r);

            Vector2 pos = sourcePos;
            SpatialComponent s = new SpatialComponent(pos, false,
                new Vector2(r.tex.Width / 2, r.tex.Height / 2));
            s.vel = Vector2.Multiply(
                new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)), Constants.FIREBALL_SPEED);
            s.angularMomentum += 0.9f;
            e.attach(s);

            if ( fireballHitbox == null )
                fireballHitbox = new CircleHitbox(r.tex.Height / 2);

            e.attach(new CollisionComponent(fireballHitbox));
            e.attach(new DecayComponent(60));
            e.attach(new DestructibleComponent());
            e.attach(new OwnableComponent(owner));
            e.attach(new DamageComponent(40));

            e.attach(new AnimationComponent(
                new List<(Animations.animate animate, int period)>{
                    (Animations.rotateColors(
                        new List<Color>() { Color.Green, Color.LightGreen, Color.ForestGreen }
                        ), 2)
                }
            ));

            return e;
        }

        //public static Entity Meteor(Vector2 source) {

        //}

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

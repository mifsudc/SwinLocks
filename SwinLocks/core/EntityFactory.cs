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
        private static Config config = Config.get();

        private static CircleHitbox playerHitbox;
        public static Entity player(Vector2 pos, int offset, IInputController controller = null) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.player, Color.White) {
                offset = new Rectangle(0, Constants.PLAYER_PILLAR * offset, Constants.PLAYER_PILLAR, Constants.PLAYER_PILLAR),
                drawRotation = false
            };
            e.attach(r);

            e.attach(new SpatialComponent( pos, true,
                new Vector2(Constants.PLAYER_PILLAR / 2, Constants.PLAYER_PILLAR / 2)));
            
            if (playerHitbox == null)
                playerHitbox = new CircleHitbox(Constants.PLAYER_PILLAR / 2);

            e.attach(new CollisionComponent(playerHitbox));
            e.attach(new BumpComponent());
            e.attach(new HealthComponent(config.PLAYER_MAX_HEALTH));
            e.attach(new DestructorComponent());
            e.attach(new ImpulsableComponent());

            e.attach(new AnimationComponent(
                new List<(Animations.animate animate, int period)>{
                    (Animations.rotator, 1)
                } ));

            if (controller != null) {
                ControllableComponent c = new ControllableComponent {
                    controller = controller
                };
                e.attach(c);
            }

            return e;
        }

        private static Hitbox pillarHitbox;
        public static Entity pillar(Vector2 pos) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.pillar, Color.LightGray);
            e.attach(r);

            e.attach( new SpatialComponent(pos, false,
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
                new Vector2(r.tex.Width / 2, r.tex.Height / 2)) {
                vel = Vector2.Multiply(
                    new Vector2( (float)Math.Cos(rot), (float)Math.Sin(rot)), config.FIREBALL_SPEED)
            };
            s.angularMomentum += 0.9f;
            e.attach(s);

            if ( fireballHitbox == null )
                fireballHitbox = new CircleHitbox(r.tex.Height / 2);

            e.attach(new CollisionComponent(fireballHitbox));
            e.attach(new DecayComponent(config.FIREBALL_TTL));
            e.attach(new DestructibleComponent());
            e.attach(new OwnableComponent(owner));
            e.attach(new DamageComponent(config.FIREBALL_DMG));
            e.attach(new ImpulseComponent(config.FIREBALL_KB));
            e.attach(new DestructorComponent());

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
                new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)), config.DRAIN_SPEED);
            s.angularMomentum += 0.9f;
            e.attach(s);

            if ( fireballHitbox == null )
                fireballHitbox = new CircleHitbox(r.tex.Height / 2);

            e.attach(new CollisionComponent(fireballHitbox));
            e.attach(new DecayComponent(config.DRAIN_TTL));
            e.attach(new DestructibleComponent());
            e.attach(new OwnableComponent(owner));
            e.attach(new DamageComponent(config.DRAIN_DMG));
            e.attach(new DestructorComponent());
            e.attach(new ImpulseComponent(config.DRAIN_KB));
            e.attach(new HealerComponent(config.DRAIN_HEAL));

            e.attach(new AnimationComponent(
                new List<(Animations.animate animate, int period)>{
                    (Animations.rotateColors(
                        new List<Color>() { Color.Green, Color.LightGreen, Color.ForestGreen }
                        ), 2)
                }
            ));

            return e;
        }

        public static Hitbox gravityHitbox;

        public static Entity gravity(Entity owner, Vector2 sourcePos, float rot) {
            Entity e = new Entity();

            RenderableComponent r = new RenderableComponent(Resources.fireball, Color.Blue);
            e.attach(r);

            Vector2 pos = sourcePos;
            SpatialComponent s = new SpatialComponent(pos, false,
                new Vector2(r.tex.Width / 2, r.tex.Height / 2)) {
                vel = Vector2.Multiply(
                    new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)), config.GRAVITY_SPEED)
            };
            s.angularMomentum += 0.9f;
            e.attach(s);

            if ( gravityHitbox == null )
                gravityHitbox = new CircleHitbox(r.tex.Height * 5);

            e.attach(new CollisionComponent(gravityHitbox));
            e.attach(new DecayComponent(config.GRAVITY_TTL));
            e.attach(new OwnableComponent(owner));
            e.attach(new ImpulseComponent(config.GRAVITY_KB));

            e.attach(new AnimationComponent(
                new List<(Animations.animate animate, int period)>{
                    (Animations.rotateColors(
                        new List<Color>() { Color.LightBlue, Color.AliceBlue, Color.SkyBlue }
                        ), 2)
                }
            ));

            return e;
        }
    }
}

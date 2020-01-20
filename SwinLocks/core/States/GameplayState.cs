using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinLocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace SwinLocks
{
    class GameplayState : GameState
    {
        List<System> renderers;
        List<System> systems;

        public GameplayState(SpriteBatch sb) {
            // Set up systems
            renderers = new List<System>();
            systems = new List<System>();

            LavaSystem lava = new LavaSystem();

            // RENDERER SYSTEMS
            renderers.Add( new TerrainSystem(sb, lava) );
            renderers.Add( new RenderingSystem(sb) );
            renderers.Add( new HudSystem(sb) );

            // CORE SYSTEMS
            systems.Add( new InputSystem() );
            systems.Add( new MovementSystem() );
            systems.Add( new CollisionSystem() );
            systems.Add( new DecaySystem() );
            systems.Add( new AnimationSystem() );
            systems.Add(lava);

            // COLLISION EVENT SYSTEMS
            systems.Add(new HealerSystem());
            systems.Add( new KnockbackSystem() );
            systems.Add( new DamageSystem() );
            systems.Add( new DestroyerSystem() ); // Must be last

            List<Vector2> playerDiff = new List<Vector2> {
                new Vector2(800, 0),
                new Vector2(0, 800),
                new Vector2(-800, 0),
                new Vector2(0, -800)
            };

            Vector2 centrePoint = new Vector2(Constants.SCREEN_X / 2, Constants.SCREEN_Y / 2);

            for ( int i = 0; i < 4; i++ ) {
                IInputController input = null;
                if (i == 0) {
                    input = new Temp2Controller();
                }
                else if (i == 1) {
                    input = new KeyboardController();
                }
                Entity e = EntityFactory.player( playerDiff[i] + centrePoint, i, input );
                e.subscribe(Subscriber.onGameEnd);
                GameContext.registerEntity(e);
            }

            List<Vector2> pillarDiff = new List<Vector2> {
                new Vector2(400, 400),
                new Vector2(-400, 400),
                new Vector2(400, -400),
                new Vector2(-400, -400)
            };

            for (int i = 0; i < 4; i++ ) {
                Entity e = EntityFactory.pillar( centrePoint + pillarDiff[i] );
                GameContext.registerEntity(e);
            }

            MediaPlayer.Play(Resources.gameplay);
        }

        public override void update() {
            foreach (System s in systems) {
                s.Execute();
            }
            GameContext.I.collRegister.clear();
        }

        public override void render(SpriteBatch sb) {
            foreach ( System s in renderers ) {
                s.Execute();
            }
        }
    }
}

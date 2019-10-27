using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinLocks;

namespace SwinLocks
{
    class GameplayState : GameState
    {
        RenderingSystem renderingSystem;
        List<System> systems;

        public GameplayState(SpriteBatch sb) {
            // Set up systems
            renderingSystem = new RenderingSystem(sb);
            systems = new List<System>();
            // CORE SYSTEMS
            systems.Add( new InputSystem() );
            systems.Add( new MovementSystem() );
            systems.Add( new CollisionSystem() );
            systems.Add( new DecaySystem() );
            systems.Add( new AnimationSystem() );

            // COLLISION EVENT SYSTEMS
            systems.Add( new DamageSystem() );
            systems.Add( new DestroyerSystem() ); // Must be last

            for (int i = 0; i < 4; i++ ) {

                IInputController input = null;
                if (i == 0) {
                    input = new Temp2Controller();
                }
                else if (i == 1) {
                    input = new KeyboardController();
                }
                Entity e = EntityFactory.player( i, input );
                GameContext.registerEntity(e);
            }

            for (int i = 0; i < 4; i++ ) {
                Entity e = EntityFactory.pillar( i % 2 * 900 + 500, i / 2 * 500 + 300);
                GameContext.registerEntity(e);
            }
        }

        public override void update() {
            foreach (System s in systems) {
                s.Execute();
            }
            GameContext.I.collRegister.clear();
        }

        public override void render(SpriteBatch sb) {
            renderingSystem.Execute();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class HudSystem : System {
        private SpriteBatch sb;
        private Config config;
        public HudSystem(SpriteBatch sb) {
            this.sb = sb;
            config = Config.get();
        }
        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<HealthComponent>();

            int i = 0;
            foreach (Entity e in ents) {
                // Draw character
                RenderableComponent r = e.get<RenderableComponent>();
                Vector2 pos = new Vector2(i * Constants.SCREEN_X / 4, Constants.SCREEN_Y - 200);
                sb.Draw(Resources.abilitySlot, pos, Color.White);
                sb.Draw(r.tex, pos, r.offset, r.col);
                Vector2 playerHealthOffset = new Vector2(0, -20);

                // draw health bar
                HealthComponent h = e.get<HealthComponent>();
                SpatialComponent s = e.get<SpatialComponent>();
                pos.X += 100;
                float healthpercent = h.health / config.PLAYER_MAX_HEALTH * 100;
                for (int j = 0; j < 100; j++ ) {
                    if ( j <= healthpercent )
                        sb.Draw(Resources.healthbar, pos, Color.Green);
                    else
                        sb.Draw(Resources.healthbar, pos, Color.Red);
                    pos.X += 5;
                }
                i++;
            }
        }
    }
}
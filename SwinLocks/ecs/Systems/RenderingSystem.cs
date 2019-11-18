using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class RenderingSystem : System {

        private SpriteBatch sb;
        public RenderingSystem(SpriteBatch sb) =>
            this.sb = sb;

        public override void Execute() {
            List<Entity> ents = GameContext.queryEntities<RenderableComponent>();
            foreach (Entity e in ents) {
                RenderableComponent r = e.get<RenderableComponent>() as RenderableComponent;
                SpatialComponent s = e.get<SpatialComponent>() as SpatialComponent;
                float rot = r.drawRotation ? s.rot : 0;
                sb.Draw(r.tex, s.pos, r.offset, r.col, rot, s.origin, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
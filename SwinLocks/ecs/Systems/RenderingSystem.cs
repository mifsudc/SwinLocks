using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class RenderingSystem : System {

        SpriteBatch sb;
        public RenderingSystem(SpriteBatch sb) {
            this.sb = sb;
        }

        public override void Execute() {
            List<Entity> ents = GameContext.I.entities.Where(e => e.has<RenderableComponent>()).ToList();
            foreach (Entity e in ents) {
                RenderableComponent r = e.get<RenderableComponent>() as RenderableComponent;
                SpatialComponent s = e.get<SpatialComponent>() as SpatialComponent;
                CollisionComponent c = e.get<CollisionComponent>() as CollisionComponent;
                Color col = c.colliding ? Color.White : Color.LightGray;
                sb.Draw(r.tex, s.pos, r.offset, col, s.rot, r.mid, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class TerrainSystem : System {

        private SpriteBatch sb;
        private LavaSystem lava;

        public TerrainSystem(SpriteBatch sb, LavaSystem lava) {
            this.sb = sb;
            this.lava = lava;
        }
        public override void Execute() {
            sb.DrawCircle(lava.bounds, 50, Color.Blue, 5);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class RenderableComponent : Component
    {
        public Texture2D tex;
        public Vector2 mid;
        public Rectangle? offset;    // draw offset
        public Color col;
        public RenderableComponent(Texture2D tex, int midScale, Color col) {
            this.tex = tex;
            mid = new Vector2(tex.Height / midScale, tex.Width / midScale);
            offset = null;
            this.col = col;
        }
    }
}

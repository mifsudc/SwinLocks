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
        public Rectangle? offset;
        public Color col;
        public bool drawRotation;
        public RenderableComponent(Texture2D tex, Color col) {
            this.tex = tex;
            offset = null;
            this.col = col;
            drawRotation = true;
        }
    }
}

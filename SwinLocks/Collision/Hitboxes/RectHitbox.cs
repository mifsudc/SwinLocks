using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace SwinLocks {
    class RectHitbox : Hitbox {

        private Vector2 dim;

        public Rectangle getBounds(Vector2 pos) {
            return RectangleExtensions.ToRectangle(
                new RectangleF( pos.X - dim.X, pos.Y - dim.Y, dim.X * 2, dim.Y * 2) );
        }

        public RectHitbox(Vector2 dim) {
            type = typeof(RectHitbox);
            this.dim = dim;
        }
    }
}

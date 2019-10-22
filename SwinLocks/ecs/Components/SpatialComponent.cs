using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class SpatialComponent : Component
    {
        public Vector2 pos;
        public Vector2 vel;
        public float rot;
        public bool friction;

        public SpatialComponent(float x, float y, bool friction)
            : this(new Vector2(x, y), friction) {}

        public SpatialComponent(Vector2 pos, bool friction) {
            this.pos = pos;
            this.friction = friction;
        }
    }
}

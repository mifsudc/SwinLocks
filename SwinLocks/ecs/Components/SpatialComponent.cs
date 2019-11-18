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
        public Vector2 origin;
        public float rot;
        public float angularMomentum;
        public bool friction;
        public bool moveable;

        public Vector2 Midpoint { get => pos + origin; }

        public SpatialComponent(float x, float y, bool friction, Vector2 origin)
            : this(new Vector2(x, y), friction, origin) {}

        public SpatialComponent(Vector2 pos, bool friction, Vector2 origin) {
            this.pos = pos;
            this.friction = friction;
            this.origin = origin;
            angularMomentum = 0;
            rot = (float) Math.PI / 2;
            moveable = true;
        }
    }
}
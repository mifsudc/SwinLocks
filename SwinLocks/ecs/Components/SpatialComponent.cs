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

        public SpatialComponent(float x, float y) {
            pos = new Vector2(x, y);
        }
    }
}

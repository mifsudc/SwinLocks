using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CircleHitbox : Hitbox {
        public float radius { get; private set; }

        public CircleHitbox(int radius) {
            type = typeof(CircleHitbox);
            this.radius = radius;
        }
    }
}

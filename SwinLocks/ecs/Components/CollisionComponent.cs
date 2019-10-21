using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace SwinLocks {
    class CollisionComponent : Component {

        public int radius;
        public bool colliding;
        public CollisionComponent(int radius) {
            colliding = false;
            this.radius = radius;
        }
    }
}

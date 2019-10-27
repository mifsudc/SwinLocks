using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace SwinLocks {
    class CollisionComponent : Component {
        public Hitbox hitbox { get; private set; }

        public CollisionComponent(Hitbox hitbox)
            => this.hitbox = hitbox;

        public Type Type { get => hitbox.type; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class OwnableComponent : Component {
        public Entity owner;

        public OwnableComponent(Entity owner) {
            this.owner = owner;
        }
    }
}

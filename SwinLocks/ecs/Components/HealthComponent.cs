using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class HealthComponent : Component {
        public int health;

        public HealthComponent(int health)
            => this.health = health;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class HealthComponent : Component {
        public float health;

        public HealthComponent(float health)
            => this.health = health;
    }
}

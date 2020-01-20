using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DamageComponent : Component {
        public int damage;
        public DamageComponent(int damage)
            => this.damage = damage;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class KnockbackComponent : Component {
        public int power;

        public KnockbackComponent(int power) =>
            this.power = power;
    }
}

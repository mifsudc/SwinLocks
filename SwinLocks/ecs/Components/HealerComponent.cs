using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class HealerComponent : Component {
        public int power { get; private set; }

        public HealerComponent(int power) =>
            this.power = power;
    }
}

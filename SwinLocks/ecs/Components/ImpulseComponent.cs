using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class ImpulseComponent : Component {
        public float power;

        public ImpulseComponent(float power) =>
            this.power = power;
    }
}

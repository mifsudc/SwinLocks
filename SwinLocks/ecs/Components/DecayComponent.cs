using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DecayComponent : Component {
        public int ttl;

        public DecayComponent(int ttl) {
            this.ttl = ttl;
        }
    }
}

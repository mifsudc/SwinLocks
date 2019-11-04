using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class ScriptingComponent : Component {
        int clock;
        List<ScriptingBehaviour> scripts;

        public ScriptingComponent() {
            clock = 0;
            scripts = new List<ScriptingBehaviour>();
        }
    }
}

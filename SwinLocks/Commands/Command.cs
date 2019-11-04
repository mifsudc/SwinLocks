using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    abstract class Command {
        public abstract void execute(Entity e, SpatialComponent s);
    }
}

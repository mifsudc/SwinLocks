using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class MeteorCommand : Command {
        public override void execute(Entity e, SpatialComponent s) => throw new NotImplementedException();
    }
}

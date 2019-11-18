using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SwinLocks {
    class BlinkCommand : Command {
        private Config config = Config.get();
        public override void execute(Entity e, SpatialComponent s) {
            s.pos.X += config.BLINK_DISTANCE * (float)Math.Cos(s.rot);
            s.pos.Y += config.BLINK_DISTANCE * (float)Math.Sin(s.rot);
            Resources.blink.Play();
        }
    }
}

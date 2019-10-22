using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    abstract class Hitbox {
        Type type;

        public void setType<T>() where T : Hitbox {
            type = typeof(T);
        }
    }
}

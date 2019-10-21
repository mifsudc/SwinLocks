using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class GameContext 
    {
        public static GameContext I;
        public List<Entity> entities;

        public GameContext() {
            if (I != null) {
                throw new Exception("There may only be one game context.");
            }
            else {
                I = this;
            }

            entities = new List<Entity>();
        }
    }
}

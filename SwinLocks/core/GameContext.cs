using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinLocks.ecs;

namespace SwinLocks.core
{
    class GameContext
    {
        public static GameContext I;
        public List<Entity> entities;

        public GameContext()
        {
            if (I != null)
            {
                throw new Exception("There may only be one game context.");
            }
            else
            {
                I = this;
            }
        }
    }
}

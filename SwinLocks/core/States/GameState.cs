using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    public abstract class GameState
    {
        public abstract void update();
        public abstract void render(SpriteBatch sb);
    }
}

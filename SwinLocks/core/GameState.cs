using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks.core
{
    abstract class GameState
    {
        public abstract void Update();
        public abstract void Render(SpriteBatch sb);
    }
}

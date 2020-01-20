using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    abstract class Subscriber {
        public static GameEndSubscriber onGameEnd = new GameEndSubscriber();
        public static ParticleSubscriber particle = new ParticleSubscriber();
        public abstract void notify(Entity e);
        public virtual void subscribe(Entity e) {}
    }
}

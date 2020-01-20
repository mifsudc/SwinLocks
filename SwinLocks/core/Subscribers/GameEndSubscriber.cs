using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class GameEndSubscriber : Subscriber {
        private List<Entity> subs;

        public GameEndSubscriber() =>
            subs = new List<Entity>();

        public override void subscribe(Entity e) =>
            subs.Add(e);

        public override void notify(Entity e) {
            subs.Remove(e);
            if (subs.Count == 1) {
                RenderableComponent r = subs[0].get<RenderableComponent>();
                r.offset = new Rectangle(300, r.offset.GetValueOrDefault().Y,
                    r.offset.GetValueOrDefault().Width, r.offset.GetValueOrDefault().Height);
                SwinLocks.state = new EndGameState(subs[0]);
            }
        }
    }
}

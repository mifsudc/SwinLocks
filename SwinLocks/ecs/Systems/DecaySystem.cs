using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class DecaySystem : System {
        Random rand;
        List<Color> cols;

        public DecaySystem() {
            rand = new Random( (int) DateTime.Now.Ticks );
            cols = new List<Color>() { Color.Orange, Color.Red, Color.Crimson };
        }

        public override void Execute() {
            List<Entity> ents = GameContext.I.entities.Where(e => e.has<DecayComponent>()).ToList();

            for ( int i = ents.Count - 1; i > -1; i--) {
                DecayComponent d = ents[i].get<DecayComponent>() as DecayComponent;
                if ( d.ttl == 0 ) {
                    GameContext.I.entities.Remove(ents[i]);
                }
                else {
                    d.ttl--;
                    if (d.ttl % 2 == 0) {
                        RenderableComponent r = ents[i].get<RenderableComponent>() as RenderableComponent;
                        r.col = cols[rand.Next(0, 2)];
                        
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class GameEndSubscriber {
        private int alive;

        public GameEndSubscriber(int players) =>
            alive = players;
        
        public void notify(Entity e) {
            if (--alive == 1) {
                Console.WriteLine("Player wins!");
            }
            Console.WriteLine("Player died");
        }
    }
}

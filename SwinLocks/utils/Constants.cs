using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    static class Constants {
        public static readonly int SCREEN_X = 1920; // 3840 1920;
        public static readonly int SCREEN_Y = 1080; // 2160 1080

        public static readonly float FRICTION = 0.99f;
        public static readonly float PLAYER_ACCELERATION = 0.1f;
        public static readonly float FIREBALL_SPEED = 10f;
        public static readonly float BUMP_EFFICIENCY = 0.7f;
        public static readonly float TURN_RATE = 0.08f;
        public static readonly int LAVA_DAMAGE = 1;
        public static readonly int LAVA_CLOCK = 30;

        // Image resource dimensions
        public static readonly int PLAYER_PILLAR = 100;
        public static readonly int FIREBALL = 50;
        public static readonly int PARTICLE = 7;
    }
}

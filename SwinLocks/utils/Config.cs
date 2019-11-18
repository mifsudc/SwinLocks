using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwinLocks {
    class Config {

        private static Config INSTANCE;

        Config() {
            if ( INSTANCE != null )
                throw new Exception("Singleton instance allowance exceeded.");
            String[] lines = File.ReadAllLines("config.txt");

            FIREBALL_DMG = int.Parse(lines[0]);
            FIREBALL_KB = float.Parse(lines[1]);
            FIREBALL_SPEED = float.Parse(lines[2]);
            GRAVITY_KB = float.Parse(lines[3]);
            GRAVITY_SPEED = float.Parse(lines[4]);
            DRAIN_DMG = int.Parse(lines[5]);
            DRAIN_HEAL = int.Parse(lines[6]);
            DRAIN_KB = float.Parse(lines[7]);
            DRAIN_SPEED = float.Parse(lines[8]);
            LAVA_DAMAGE = float.Parse(lines[9]);
            PLAYER_MAX_HEALTH = int.Parse(lines[10]);
            FIREBALL_TTL = int.Parse(lines[11]);
            GRAVITY_TTL = int.Parse(lines[12]);
            DRAIN_TTL = int.Parse(lines[13]);
            BLINK_DISTANCE = float.Parse(lines[14]);
        }

        public static Config get() {
            if (INSTANCE == null) {
                INSTANCE = new Config();
            }
            return INSTANCE;
        }

        public int FIREBALL_DMG;
        public float FIREBALL_KB;
        public float FIREBALL_SPEED;
        public float GRAVITY_KB;
        public float GRAVITY_SPEED;
        public int DRAIN_DMG;
        public int DRAIN_HEAL;
        public float DRAIN_KB;
        public float DRAIN_SPEED;
        public float LAVA_DAMAGE;
        public int PLAYER_MAX_HEALTH;
        public int FIREBALL_TTL;
        public int GRAVITY_TTL;
        public int DRAIN_TTL;
        public float BLINK_DISTANCE;
    }
}

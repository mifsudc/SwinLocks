using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SwinLocks {
    static class Resources {
        public static Texture2D player;
        public static Texture2D pillar;
        public static Texture2D fireball;
        public static Texture2D lightning;
        public static Texture2D particle;
        public static Texture2D abilitySlot;
        public static Texture2D healthbar;

        public static SoundEffect shootFireball;
        public static SoundEffect explode;
        public static SoundEffect shootGravity;
        public static SoundEffect blink;

        public static Song menu;
        public static Song gameplay;

        public static SpriteFont font;
    }
}

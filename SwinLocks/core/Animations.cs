using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    static class Animations {

        private static Random rand = new Random();

        public delegate void animate(Entity e);

        public static animate rotateColors(List<Color> colours) {

            List<Color> cols = colours;

            return delegate(Entity e) {
                RenderableComponent r = e.get<RenderableComponent>();
                r.col = cols[rand.Next(0, 2)];
            };
        }

        public static void rotator(Entity e) {
            RenderableComponent r = e.get<RenderableComponent>();
            SpatialComponent s = e.get<SpatialComponent>();

            Rectangle rect = (Rectangle)r.offset;
            int x = (int) Math.Floor((s.rot + Math.PI / 8) / (Math.PI / 4));

            if ( x > 7 )
                x -= 1;

            rect.X = x * 100;
            r.offset = rect;
        }
    }
}
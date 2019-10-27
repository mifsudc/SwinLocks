using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class ExtensionMethods {
        public static Vector2 polarVector(float magnitude, float rotation) {
            return new Vector2( magnitude * (float)Math.Cos(rotation),
                magnitude * (float)Math.Sin(rotation) );
        }
    }
}

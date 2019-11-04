using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SwinLocks {
    class BlinkCommand : Command {
        public override void execute(Entity e, SpatialComponent s) {
            //ScriptingComponent script = new ScriptingComponent();

            //List<(Animations.animate, int)> animations = new List<(Animations.animate, int)>() {
            //    ( Animations.rotateColors(
            //        new List<Color>() { Color.Green, Color.LightBlue, Color.ForestGreen } ),
            //    2 )
            //};

            //AnimationComponent a = e.has<AnimationComponent>() ?
            //    e.get<AnimationComponent>() :
            //    new AnimationComponent();

            //e.attach(new ScriptingComponent());
            s.pos.X += 3 * (float) Math.Cos(s.rot);
            s.pos.Y += 3 * (float) Math.Sin(s.rot);
        }
    }
}

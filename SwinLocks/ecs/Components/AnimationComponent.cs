using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class AnimationComponent : Component {

        public int step;
        public int majorCycle { get; private set; }

        public List<(Animations.animate animate, int period)> animations { get; private set; }

        public AnimationComponent() : this(new List<(Animations.animate animate, int period)>()) {}

        public AnimationComponent(List<(Animations.animate animate, int period)> animations) {
            this.animations = animations;
            step = 0;
            majorCycle = animations.Aggregate(0, func: (acc, val) => acc *= val.period );
        }

        public void addAnimation( (Animations.animate animate, int period) animation) {
            animations.Add(animation);
        }

        
    }
}

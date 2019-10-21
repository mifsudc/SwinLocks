using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    static class EntityFactory {
        public static Entity player(int i, IInputController controller = null) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.player, i, 4);
            e.attach(r);
            e.attach(new SpatialComponent(300 * i + 100f, 100f));
            e.attach(new CollisionComponent(r.tex.Width / 4));

            if (controller != null) {
                ControllableComponent c = new ControllableComponent();
                c.Controller = controller;
                e.attach(c);
            }

            return e;
        }

        public static Entity pillar(int x, int y) {
            Entity e = new Entity();
            RenderableComponent r = new RenderableComponent(Resources.pillar, 0, 2);
            e.attach(r);
            e.attach(new SpatialComponent(x, y));
            e.attach(new CollisionComponent(r.tex.Width / 2));
            e.attach(new BumpComponent());

            return e;
        }
    }
}

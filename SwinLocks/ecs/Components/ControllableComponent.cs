using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class ControllableComponent : Component {

        public CommandProcessor skillProc { get; private set; }
        public IInputController controller { get; set; }

        public ControllableComponent() {
            skillProc = new CommandProcessor();
            skillProc.addSkill(Controller.Command.Sk1, new FireballCommand());
            skillProc.addSkill(Controller.Command.Sk2, new BlinkCommand());
            skillProc.addSkill(Controller.Command.Sk3, new DrainCommand());
            skillProc.addSkill(Controller.Command.Sk4, new GravityCommand());
        }
    }
}

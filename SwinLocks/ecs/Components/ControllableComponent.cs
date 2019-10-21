using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks
{
    class ControllableComponent : Component {

        private IInputController controller;

        public IInputController Controller { get => controller; set => controller = value; }
    }
}

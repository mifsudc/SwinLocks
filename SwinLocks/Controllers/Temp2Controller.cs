using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class Temp2Controller : IInputController {

        public CommandProcessor skillProc { get; private set; }

        public List<Controller.Command> Poll() {
            List<Controller.Command> actions = new List<Controller.Command>();

            if ( Input.keyDown(Keys.A) ) {
                actions.Add(Controller.Command.Left);
            }

            if ( Input.keyDown(Keys.D) ) {
                actions.Add(Controller.Command.Right);
            }
            
            if ( Input.keyDown(Keys.W) ) {
                actions.Add(Controller.Command.Up);
            }
            else if ( Input.keyDown(Keys.S) ) {
                actions.Add(Controller.Command.Down);
            }

            if ( Input.keyPressed(Keys.E) ) {
                actions.Add(Controller.Command.Sk1);
            }

            else if ( Input.keyPressed(Keys.R) ) {
                actions.Add(Controller.Command.Sk2);
            }

            else if ( Input.keyPressed(Keys.D3) ) {
                actions.Add(Controller.Command.Sk3);
            }

            else if ( Input.keyPressed(Keys.D4) ) {
                actions.Add(Controller.Command.Sk4);
            }

            return actions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SwinLocks {

    class KeyboardController : IInputController {

        public List<Controller.Command> Poll() {
            List<Controller.Command> actions = new List<Controller.Command>();

            if ( Input.keyDown(Keys.Left) ) {
                actions.Add(Controller.Command.Left);
            }

            if ( Input.keyDown(Keys.Right) ) {
                actions.Add(Controller.Command.Right);
            }

            if ( Input.keyDown(Keys.Up) ) {
                actions.Add(Controller.Command.Up);
            }
            else if ( Input.keyDown(Keys.Down) ) {
                actions.Add(Controller.Command.Down);
            }

            if ( Input.keyPressed(Keys.OemPeriod) ) {
                actions.Add(Controller.Command.Sk1);
            }

            else if ( Input.keyPressed(Keys.I) ) {
                actions.Add(Controller.Command.Sk2);
            }

            else if ( Input.keyPressed(Keys.O) ) {
                actions.Add(Controller.Command.Sk3);
            }

            else if ( Input.keyPressed(Keys.P) ) {
                actions.Add(Controller.Command.Sk4);
            }

            return actions;
        }
    }
}

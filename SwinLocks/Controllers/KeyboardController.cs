using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SwinLocks {

    class KeyboardController : IInputController {

        public List<Command> Poll() {
            List<Command> actions = new List<Command>();

            if ( Input.keyDown(Keys.Left) ) {
                actions.Add(Command.Left);
            }

            if ( Input.keyDown(Keys.Right) ) {
                actions.Add(Command.Right);
            }

            if ( Input.keyDown(Keys.Up) ) {
                actions.Add(Command.Up);
            }
            else if ( Input.keyDown(Keys.Down) ) {
                actions.Add(Command.Down);
            }

            if ( Input.keyPressed(Keys.U) ) {
                actions.Add(Command.Sk1);
            }

            else if ( Input.keyPressed(Keys.I) ) {
                actions.Add(Command.Sk2);
            }

            else if ( Input.keyPressed(Keys.O) ) {
                actions.Add(Command.Sk3);
            }

            else if ( Input.keyPressed(Keys.P) ) {
                actions.Add(Command.Sk4);
            }

            return actions;
        }
    }
}

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class Temp2Controller : IInputController {
        public List<Command> Poll() {
            List<Command> actions = new List<Command>();

            if ( Input.keyDown(Keys.A) ) {
                actions.Add(Command.Left);
            }

            if ( Input.keyDown(Keys.D) ) {
                actions.Add(Command.Right);
            }

            if ( Input.keyDown(Keys.W) ) {
                actions.Add(Command.Up);
            }
            else if ( Input.keyDown(Keys.S) ) {
                actions.Add(Command.Down);
            }

            if ( Input.keyPressed(Keys.D1) ) {
                actions.Add(Command.Sk1);
            }

            else if ( Input.keyPressed(Keys.D2) ) {
                actions.Add(Command.Sk2);
            }

            else if ( Input.keyPressed(Keys.D3) ) {
                actions.Add(Command.Sk3);
            }

            else if ( Input.keyPressed(Keys.D4) ) {
                actions.Add(Command.Sk4);
            }

            return actions;
        }
    }
}

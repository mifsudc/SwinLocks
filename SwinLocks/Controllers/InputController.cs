﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    interface IInputController {

        CommandProcessor skillProc { get; }
        List<Controller.Command> Poll();
    }
}

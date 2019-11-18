using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CommandProcessor {
        private Dictionary<Controller.Command, Command> skills;

        public CommandProcessor()
            => skills = new Dictionary<Controller.Command, Command>();

        public void addSkill(Controller.Command slot, Command skill)
            => skills.Add(slot, skill);

        public void Process(Controller.Command slot, Entity e) =>
            skills[slot]?.execute(e, e.get<SpatialComponent>() );
    }
}

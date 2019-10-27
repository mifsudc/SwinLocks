using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CommandProcessor {
        private Dictionary<int, Commands.Command> skills;

        CommandProcessor()
            => skills = new Dictionary<int, Commands.Command>();

        public void addSkill(int slot, Commands.Command skill)
            => skills.Add(slot, skill);

        public void Process(int slot, Entity e) {
            skills[slot]?.execute(e, e.get<SpatialComponent>() );
        }
    }
}

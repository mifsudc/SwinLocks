using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinLocks {
    class CommandProcessor {
        private Dictionary<int, Command> skills;

        public CommandProcessor()
            => skills = new Dictionary<int, Command>();

        public void addSkill(int slot, Command skill)
            => skills.Add(slot, skill);

        public void Process(int slot, Entity e) {
            skills[slot]?.execute(e, e.get<SpatialComponent>() );
        }
    }
}

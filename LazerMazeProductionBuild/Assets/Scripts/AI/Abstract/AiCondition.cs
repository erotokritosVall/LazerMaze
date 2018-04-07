using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.AI.Abstract {
    public abstract class AiCondition {
        public abstract bool CheckCondition(StateController stateController);
    }
}

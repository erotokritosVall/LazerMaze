using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.AI.Abstract {
    public abstract class AiState {
        AiAction[] actions;
        AiCondition[] conditions;

        public abstract void OnStateEnter(StateController controller);
        public abstract void OnStateExit(StateController controller);
        public abstract void OnStateUpdate(StateController controller);
    }
}

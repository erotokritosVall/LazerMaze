using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.AI.Abstract {
    public abstract class AiState {
        public AiAction[] actions;
        public AiCondition[] conditions;
        public StateTag stateTag;
        public AiState(AiAction[] actions, AiCondition[] conditions) {
            this.actions = actions;
            this.conditions = conditions;
        }

        public abstract void OnStateEnter(StateController stateController);
        public abstract void OnStateExit(StateController stateController);
        public abstract void OnStateUpdate(StateController stateController);
    }
}

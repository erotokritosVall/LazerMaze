using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.States {

    public class AttackState : BasicAiState {

        public AttackState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            Vector3 lookDirection = stateController.Owner.GetMoveDirection(stateController.Owner.Player.position);
            stateController.Owner.animatedComponent.SetAnimatorParameters(lookDirection.x, lookDirection.z);
            stateController.Owner.movableComponent.MoveDirection = Vector3.zero;
        }
    }
}

using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.States {

    /**
     * Extends basic state's functionallity as needed
     */

    public class AttackState : BasicAiState {

        public AttackState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            Vector3 lookDirection = stateController.Owner.GetMoveDirection(PlayerController.Instance.transform.position);
            stateController.Owner.animatedComponent.SetAnimatorParameters(lookDirection.x, lookDirection.z);
            stateController.Owner.movableComponent.MoveDirection = Vector3.zero;
        }
    }
}

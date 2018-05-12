using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Conditions {

    /**
     * Condition used for mazipede body parts to start fleeing
     */

    public class FollowingToFleeCondition : AiCondition {

        private MazipedeHeadController head;

        public FollowingToFleeCondition(Transform head) {
            this.head = head.GetComponent<MazipedeHeadController>();
        }

        public override bool CheckCondition(StateController stateController) {
            stateController.Owner.movableComponent.MoveSpeed = head.movableComponent.MoveSpeed;
            if (head == null) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Fleeing);
                return true;
            }
            return false;
        }
    }
}

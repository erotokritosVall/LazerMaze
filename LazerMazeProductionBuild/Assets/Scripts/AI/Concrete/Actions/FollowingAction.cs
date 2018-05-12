using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Actions {

    /**
     * Action used only in mazipede body parts to follow each other
     */

    public class FollowingAction : AiAction {

        private Transform partToFollow;

        public FollowingAction(Transform target) {
            partToFollow = target;
        }

        public override void Act(StateController stateController) {
            if (partToFollow != null) {
                if (!stateController.Owner.IsDistanceLessOrEqualThan(partToFollow.position, 0.03f)) {
                    stateController.Owner.movableComponent.MoveDirection = stateController.Owner.GetMoveDirection(partToFollow.position);
                    stateController.Owner.movableComponent.Move();
                } else {
                    stateController.Owner.movableComponent.MoveDirection = Vector3.zero;
                }
            }          
        }
    }
}

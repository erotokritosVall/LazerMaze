using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class MoveAction : AiAction {
        private Vector3 moveDirection;
        public override void Act(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.NextNode, 0.02f)) {
                stateController.owner.NextNode = stateController.owner.GetNextWaypoint();
                if (!stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.NextNode, 1.5f)) {
                    stateController.owner.NextNode = stateController.owner.transform.position;
                    stateController.owner.ClearWaypoints();
                }
                moveDirection = stateController.owner.GetMoveDirection(stateController.owner.NextNode);
            } else {           
                stateController.owner.componentManager.movableComponent.Move(moveDirection.x, moveDirection.z);
            }
        }
    }
}

using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class MoveAction : AiAction {
        public override void Act(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.NextNode, 0.02f)) {
                stateController.owner.NextNode = stateController.owner.GetNextWaypoint();
                if (!stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.NextNode, 1.5f)) {
                    stateController.owner.NextNode = stateController.owner.transform.position;
                    stateController.owner.ClearWaypoints();
                }
            } else {
                Vector3 moveDirection = stateController.owner.GetMoveDirection(stateController.owner.NextNode);
                stateController.owner.componentManager.movableComponent.Move(moveDirection.x, moveDirection.z);
            }
        }
    }
}

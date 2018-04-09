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
                    stateController.owner.componentManager.movableComponent.StopMovement();
                    Debug.Log(stateController.owner.NextNode);
                }    
            } else {
                moveDirection = stateController.owner.GetMoveDirection(stateController.owner.NextNode);
                stateController.owner.componentManager.movableComponent.Move(moveDirection.x, moveDirection.z);
                Debug.Log(stateController.owner.NextNode);
            }
        }
    }
}

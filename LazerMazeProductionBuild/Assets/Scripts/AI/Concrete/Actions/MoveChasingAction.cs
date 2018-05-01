using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class MoveChasingAction : AiAction {

        public override void Act(StateController stateController) {
            if (stateController.owner.IsTargetInView()) {
                stateController.owner.movableComponent.MoveDirection = stateController.owner.GetMoveDirection(stateController.owner.Player.position);
                stateController.owner.movableComponent.Move();
                stateController.owner.NextNode = stateController.owner.transform.position;
                stateController.owner.ClearWaypoints();
            } else {
                if (stateController.owner.HasPath()) {
                    if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.NextNode, 0.02f)) {
                        stateController.owner.GetNextWaypoint();
                        stateController.owner.movableComponent.MoveDirection = stateController.owner.GetMoveDirection(stateController.owner.NextNode);
                    }
                    stateController.owner.movableComponent.Move();
                } else {
                    stateController.owner.RequestPath(stateController.owner.Player.position);
                }
            }
        }
    }
}

using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.AI.Concrete.Actions {

    /**
     * Basic chasing functionality. Follows a path if player is not in line of sight , otherwise it immediatelly follows the player.
     * Interrupted if Player gets in attack range , or if Player moves too far away(this applies only for certain enemies)
     */
    public class ChasingAction : AiAction {

        private static readonly float distanceForWaypoint = 0.02f;

        public override void Act(StateController stateController) {
            if (stateController.Owner.IsPlayerInView(stateController.Owner.ChaseRange)) {
                stateController.Owner.movableComponent.MoveDirection = stateController.Owner.GetMoveDirection(PlayerController.Instance.transform.position);
                stateController.Owner.movableComponent.Move();
                stateController.Owner.NextNode = stateController.Owner.transform.position;
                stateController.Owner.ClearPath();
            } else {
                if (stateController.Owner.HasPath()) {
                    if (stateController.Owner.IsDistanceLessOrEqualThan(stateController.Owner.NextNode, distanceForWaypoint)) {
                        stateController.Owner.GetNextWaypoint();
                        stateController.Owner.movableComponent.MoveDirection = stateController.Owner.GetMoveDirection(stateController.Owner.NextNode);
                    }
                    stateController.Owner.movableComponent.Move();
                } else {
                    stateController.Owner.RequestPath(PlayerController.Instance.transform.position);
                }
            }
        }
    }
}

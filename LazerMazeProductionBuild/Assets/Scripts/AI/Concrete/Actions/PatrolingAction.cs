using UnityEngine;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Managers;

namespace Assets.Scripts.AI.Concrete.Actions {

    public class PatrolingAction : AiAction {

        private static readonly float distanceForWaypoint = 0.02f;

        public override void Act(StateController stateController) {
            if (stateController.Owner.HasPath()) {
                if (stateController.Owner.IsDistanceLessOrEqualThan(stateController.Owner.NextNode, distanceForWaypoint)) {
                    stateController.Owner.GetNextWaypoint();
                    stateController.Owner.movableComponent.MoveDirection = stateController.Owner.GetMoveDirection(stateController.Owner.NextNode);
                }
                stateController.Owner.movableComponent.Move();
            } else {
                stateController.Owner.RequestPath(GetRandomPoint());
            }
        }

        private static Vector3 GetRandomPoint() {
            float x = Random.Range(0, BoardManager.Instance.SizeX - 1);
            float z = Random.Range(0, BoardManager.Instance.SizeZ - 1);
            return new Vector3(x, 0, z);
        }
    }
}

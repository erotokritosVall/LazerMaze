using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class PatrolConditionRanged : AiCondition {
        private const string playerTag = "Player";

        public override bool CheckCondition(StateController stateController) {
            RaycastHit hitObject;
            Ray ray = new Ray(stateController.owner.transform.position, stateController.owner.GetMoveDirection(stateController.owner.player.position));
            if (Physics.Raycast(ray, out hitObject, stateController.owner.AttackRange)) {
                if (hitObject.transform.CompareTag(playerTag)) {
                    stateController.stateToTransition = stateController.owner.GetStateByTag(StateTag.Attacking);
                    return true;
                }
            }
            return false;
        }
    }
}

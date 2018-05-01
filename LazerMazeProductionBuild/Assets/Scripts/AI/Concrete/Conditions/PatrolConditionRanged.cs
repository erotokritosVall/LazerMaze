using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class PatrolConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            const string playerTag = "Player";
            RaycastHit hitObject;
            Ray ray = new Ray(stateController.owner.transform.position, stateController.owner.GetMoveDirection(stateController.owner.Player.position));
            if (Physics.Raycast(ray, out hitObject, stateController.owner.AttackRange)) {
                if (hitObject.transform.CompareTag(playerTag)) {
                    stateController.nextState = stateController.owner.GetState(StateTag.Attacking);
                    return true;
                }
            }
            return false;
        }
    }
}

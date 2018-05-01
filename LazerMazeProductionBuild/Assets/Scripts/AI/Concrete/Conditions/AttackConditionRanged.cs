using UnityEngine;
using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class AttackConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            const string playerTag = "Player";
            RaycastHit hitObject;
            Ray ray = new Ray(stateController.owner.transform.position, stateController.owner.GetMoveDirection(stateController.owner.Player.position));
            if (Physics.Raycast(ray, out hitObject, stateController.owner.AttackRange)) {
                if (hitObject.transform.CompareTag(playerTag)) {
                    stateController.nextState = stateController.owner.GetState(StateTag.Chasing);
                    return true;
                }
            }
            return false;
        }
    }
}

using UnityEngine;
using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class MovePatrolerAction : MoveAction {
        public override void Act(StateController stateController) {
            if (stateController.owner.HasPath()) {
                base.Act(stateController);
            } else {
                if (!stateController.owner.BIsPathPending) {
                    Vector3 patrolTarget = GetRandomPoint();
                    stateController.owner.RequestPath(patrolTarget);
                }
            }          
        }

        private Vector3 GetRandomPoint() {
            float x = Random.Range(0, 14);
            float z = Random.Range(0, 14);
            return new Vector3(x, 0, z);
        }
    }
}

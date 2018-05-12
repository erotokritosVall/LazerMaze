using Assets.Scripts.AI.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.Actions {

    /**
     * Basic flee action
     */

    public class FleeAction : PatrolingAction {

        private static float fleeTime = 10.0f;
        private float timer = 0.0f;

        public override void Act(StateController stateController) {
            if (timer < fleeTime) {
                base.Act(stateController);
            } else {
                return;
            }
            timer += Time.deltaTime;
        }
    }
}

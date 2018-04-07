using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class MoveChasingAction : MoveAction {
        public override void Act(StateController stateController) {
            if (stateController.owner.HasPath()) {
                base.Act(stateController);
            } else {
                if (!stateController.owner.BIsPathPending) {
                    stateController.owner.RequestPath(stateController.owner.player.position);                    
                }
            }
        }
    }
}

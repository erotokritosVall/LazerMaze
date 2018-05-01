using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.AI.Concrete.States {
    public class AttackState : BasicAiState {

        public AttackState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            stateController.owner.GetComponent<Movable>().MoveDirection = Vector3.zero;
        }
    }
}

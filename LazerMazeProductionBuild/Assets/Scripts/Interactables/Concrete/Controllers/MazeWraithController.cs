using Assets.Scripts.Interactables.Concrete.Components;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.AI.Concrete.Actions;
using Assets.Scripts.AI.Concrete.Conditions;
using Assets.Scripts.AI.Concrete.States;
using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    [RequireComponent(typeof(AnimatedHittable))]
    [RequireComponent(typeof(AttackableAnimated))]
    [RequireComponent(typeof(AttackerMelee))]
    [RequireComponent(typeof(MovableBasic))]
    public class MazeWraithController : Enemy {
        private void Awake() {
            AiAction[] chasingActions = {
                new MoveChasingAction()
            };
            AiCondition[] chasingConditions = {
                new ChaseMeleeConditionOne(),
            };
            AiAction[] attackAction = {
                new AttackAction()
            };
            AiCondition[] attackCondition = {
                new AttackConditionMelee()
            };
            states.Add(StateTag.Chasing, new ChasingState(chasingActions, chasingConditions));
            states.Add(StateTag.Attacking, new AttackState(attackAction, attackCondition));
            stateController = new StateController(GetState(StateTag.Chasing), this);
        }

        private void Start() {
            Initialise(3.0f, 5.0f, 0.2f, Mathf.Infinity);
            GetComponent<AttackerMelee>().target = Player.GetComponent<Attackable>();
        }

        private void Update() {
            attackerComponent.Tick();
            stateController.Tick();
            animatedComponent.SetAnimatorParameters(movableComponent.MoveDirection.x, movableComponent.MoveDirection.z);
        }
    }
}

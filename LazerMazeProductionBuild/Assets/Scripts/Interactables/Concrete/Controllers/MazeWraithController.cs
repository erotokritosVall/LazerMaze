using Assets.Scripts.Interactables.Concrete.Components;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.AI.Concrete.Actions;
using Assets.Scripts.AI.Concrete.Conditions;
using Assets.Scripts.AI.Concrete.States;
using Assets.Scripts.Interactables.Concrete.Managers;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    [RequireComponent(typeof(AnimatedHittable))]
    [RequireComponent(typeof(AttackableAnimated))]
    [RequireComponent(typeof(AttackerMelee))]
    [RequireComponent(typeof(MovableAnimated))]
    [RequireComponent(typeof(ComponentManager))]
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
            ChasingState chasingState = new ChasingState(chasingActions, chasingConditions);
            states.Add(chasingState);
            states.Add(new AttackState(attackAction, attackCondition));
            stateController = new StateController(chasingState, this);
        }

        private void Start() {
            Initialise(5.0f, 5.0f, 0.3f, Mathf.Infinity);
        }
        private void Update() {
            stateController.Tick();
        }
    }
}

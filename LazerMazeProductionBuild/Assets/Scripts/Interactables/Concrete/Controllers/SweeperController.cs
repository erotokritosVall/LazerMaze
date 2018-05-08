using Assets.Scripts.Interactables.Concrete.Components;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.AI.Concrete.Actions;
using Assets.Scripts.AI.Concrete.Conditions;
using Assets.Scripts.AI.Concrete.States;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    /**
     * Initialises and controls sweepers
     */

     [RequireComponent(typeof(AnimatedHittable))]
     [RequireComponent(typeof(AttackableSweeper))]
     [RequireComponent(typeof(AttackerSweeper))]
     [RequireComponent(typeof(MovableWithoutRB))]
    public class SweeperController : Enemy {

        private void Awake() {
            AiAction[] chasingAction = {
                new ChasingAction()
            };
            AiCondition[] chasingCondition = {
                new ChaseToAttackConditionMelee()
            };

            AiAction[] attackAction = {
                new AttackMeleeAction()
            };
            AiCondition[] attackCondition = {
                new AttackToChaseConditionMelee()
            };

            states.Add(StateTag.Chasing, new ChasingState(chasingAction, chasingCondition));
            states.Add(StateTag.Attacking, new AttackState(attackAction, attackCondition));
            stateController = new StateController(GetState(StateTag.Chasing), this);
        }

        private void Start() {
            InitialiseStats(4.5f, 50.0f, 0.1f, Mathf.Infinity);
            stateController.StartUp();
        }
    }
}

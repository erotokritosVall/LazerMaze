using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Components;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.AI.Concrete.Actions;
using Assets.Scripts.AI.Concrete.Conditions;
using Assets.Scripts.AI.Concrete.States;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    /**
     * Controller that handles the mazipede's head
     */

    [RequireComponent(typeof(AnimatedBasic))]
    [RequireComponent(typeof(AttackerMelee))]
    [RequireComponent(typeof(AttackableNotAnimated))]
    [RequireComponent(typeof(MovableWithoutRB))]
    public class MazipedeHeadController : Enemy {

        private void Awake() {
            AiAction[] patrolAction = {
                new PatrolingAction()
            };
            AiCondition[] patrolCondition = {
                new PatrolToChaseConditionMelee()
            };

            AiAction[] chaseAction = {
                new ChasingAction()
            };
            AiCondition[] chaseCondition = {
                new ChaseToAttackConditionMelee(),
                new ChaseToPatrolCondition()
            };

            AiAction[] attackAction = {
                new AttackMeleeAction()
            };
            AiCondition[] attackCondition = {
                new AttackToChaseConditionMelee()
            };

            states.Add(StateTag.Patroling, new PatrolState(patrolAction, patrolCondition));
            states.Add(StateTag.Chasing, new ChasingState(chaseAction, chaseCondition));
            states.Add(StateTag.Attacking, new AttackState(attackAction, attackCondition));
            stateController = new StateController(GetState(StateTag.Patroling), this);
        }

        private void Start() {
            InitialiseStats(3.0f, 10.0f, 0.2f, 20.0f);
        }
    }
}

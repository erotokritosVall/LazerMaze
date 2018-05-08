using Assets.Scripts.Interactables.Concrete.Components;
using Assets.Scripts.AI.Concrete.Actions;
using Assets.Scripts.AI.Concrete.Conditions;
using Assets.Scripts.AI.Concrete.States;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    /**
     * Initialises and controls galactic convicts
     */

    [RequireComponent(typeof(AnimatedRanged))]
    [RequireComponent(typeof(AttackerRanged))]
    [RequireComponent(typeof(AttackableAnimated))]
    [RequireComponent(typeof(MovableWithoutRB))]
    public class GalacticConvictController : Enemy {

        private void Awake() {
            AiAction[] chaseAction = {
                new ChasingAction()
            };
            AiCondition[] chaseConditions = {
                new ChaseToPatrolCondition(),
                new ChaseToAttackConditionRanged()
            };

            AiAction[] patrolAction = {
                new PatrolingAction()
            };
            AiCondition[] patrolConditions = {
                new PatrolToChaseConditionRanged()
            };

            AiAction[] attackAction = {
                new AttackRangedAction()
            };
            AiCondition[] attackConditions = {
                new AttackToChaseConditionRanged()
            };

            states.Add(StateTag.Chasing, new ChasingState(chaseAction, chaseConditions));
            states.Add(StateTag.Patroling, new PatrolState(patrolAction, patrolConditions));
            states.Add(StateTag.Attacking, new AttackState(attackAction, attackConditions));
            stateController = new StateController(GetState(StateTag.Patroling), this);
        }

        private void Start() {
            InitialiseStats(3.0f, 5.0f, 10.0f, 15.0f);
            GetComponent<AttackerRanged>().target = PlayerController.Instance.GetComponent<Attackable>();
            stateController.StartUp();
        }
    }
}

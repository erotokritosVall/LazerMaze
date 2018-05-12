using Assets.Scripts.Interactables.Concrete.Components;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.AI.Concrete.Actions;
using Assets.Scripts.AI.Concrete.Conditions;
using Assets.Scripts.AI.Concrete.States;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    /**
     * Handle mazipede's body functionality
     */

    [RequireComponent(typeof(AttackableMazipedeBody))]
    [RequireComponent(typeof(AnimatedBasic))]
    [RequireComponent(typeof(MovableWithoutRB))]
    public class MazipedeBodyController : Enemy {

        private void Awake() {
            movableComponent = GetComponent<MovableWithoutRB>();
            animatedComponent = GetComponent<AnimatedBasic>();
            movableComponent.MoveSpeed = 3.0f;
        }

        private void Start() {
            int i = 1;
            for ( ; i < transform.parent.childCount; i++) {
                if (transform.parent.GetChild(i) == transform) {
                    break;
                }
            }

            FollowingAction[] followingAction = {
                new FollowingAction(transform.parent.GetChild(i - 1))
            };
            FollowingToFleeCondition[] followingToFleeCondition = {
                new FollowingToFleeCondition(transform.parent.GetChild(0))
            };

            FleeAction[] fleeingAction = {
                new FleeAction()
            };
            EmptyCondition[] emptyCondition = {
                new EmptyCondition()
            };

            states.Add(StateTag.Chasing, new ChasingState(followingAction, followingToFleeCondition));
            states.Add(StateTag.Fleeing, new FleeState(fleeingAction, emptyCondition));
            stateController = new StateController(GetState(StateTag.Chasing), this);
            stateController.StartUp();
        }
    }
}

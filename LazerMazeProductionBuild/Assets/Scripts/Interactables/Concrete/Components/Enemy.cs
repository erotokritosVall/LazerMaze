using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Managers;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Base class for every enemy in the game
     */

    public class Enemy : MonoBehaviour {

        private bool bIsPathPending = false;
        private Stack<Vector3> waypoints = new Stack<Vector3>();

        protected Dictionary<StateTag,AiState> states = new Dictionary<StateTag, AiState>();
        protected StateController stateController { get; set; }

        public Attacker attackerComponent { get; private set; }
        public Animated animatedComponent { get; private set; }
        public Movable movableComponent { get; private set; }
        public float AttackRange { get; private set; }
        public float ChaseRange { get; private set; }
        public Vector3 NextNode { get; set; }

        private void SetPath(Stack<Vector3> path) {
            waypoints = path;
            bIsPathPending = false;
        }

        protected void InitialiseStats(float moveSpeed, float attackDamage, float attackRange, float chaseRange) {
            NextNode = transform.position;
            attackerComponent = GetComponent<Attacker>();
            movableComponent = GetComponent<Movable>();
            animatedComponent = GetComponent<Animated>();
            movableComponent.MoveSpeed = moveSpeed;
            attackerComponent.AttackDamage = attackDamage;
            AttackRange = attackRange;
            ChaseRange = chaseRange;
        }

        protected virtual void Update() {
            stateController.Tick();
            animatedComponent.SetAnimatorParameters(movableComponent.MoveDirection.x, movableComponent.MoveDirection.z);
        }

        public bool IsPlayerInView(float distanceToCheck) {
            if (stateController.Owner.IsDistanceLessOrEqualThan(PlayerController.Instance.transform.position, distanceToCheck)) {
                const float sphereRadius = 0.15f;
                RaycastHit hitObject;
                Ray ray = new Ray(transform.position, GetMoveDirection(PlayerController.Instance.transform.position));
                if (Physics.SphereCast(ray, sphereRadius, out hitObject, distanceToCheck) &&
                    hitObject.transform.CompareTag(PlayerController.Instance.tag)) {
                    return true;
                }
            }
            return false;
        }

        public void RequestPath(Vector3 targetPosition) {
            if (!bIsPathPending) {
                bIsPathPending = true;
                PathfindingManager.Instance.NewPathRequest(transform.position, targetPosition, path => SetPath(path));
            }
        }

        public bool HasPath() {
            return waypoints.Count > 0;
        }

        public void ClearPath() {
            waypoints.Clear();
        }

        public void GetNextWaypoint() {
            NextNode = waypoints.Pop();
        }

        public AiState GetState(StateTag tag) {
            return states[tag];
        }

        public Vector3 GetMoveDirection(Vector3 target) {
            return (target - transform.position).normalized;
        }

        public bool IsDistanceLessOrEqualThan(Vector3 target, float value) {
            return (transform.position - target).sqrMagnitude <= value;
        }
    }
}

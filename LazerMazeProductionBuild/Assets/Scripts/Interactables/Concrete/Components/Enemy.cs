using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Interactables.Concrete.Components {

    public class Enemy : MonoBehaviour {

        protected Dictionary<StateTag,AiState> states = new Dictionary<StateTag, AiState>();
        public Attacker attackerComponent { get; private set; }
        public Animated animatedComponent { get; private set; }
        public Movable movableComponent { get; private set; }
        public Transform Player { get; private set; }
        public StateController stateController { get; set; }
        public float AttackRange { get; private set; }
        public float ChaseRange { get; private set; }
        public Stack<Vector3> waypoints = new Stack<Vector3>();
        public bool bIsPathPending = false;
        public bool BIsPathPending {
            get { return bIsPathPending; }
        }
        public Vector3 NextNode { get; set; }
        public Vector3 cachedPosition;
        public void SetPath(Stack<Vector3> path) {
            waypoints = path;
            bIsPathPending = false;
        }

        public bool IsTargetInView() {
            const float sphereRadius = 0.15f;
            const float viewDistance = 10.0f;
            if (stateController.owner.IsDistanceLessOrEqualThan(Player.position, viewDistance)) {
                RaycastHit hitObject;
                Ray ray = new Ray(transform.position, GetMoveDirection(Player.position));
                if (Physics.SphereCast(ray, sphereRadius, out hitObject, viewDistance) &&
                    hitObject.transform.CompareTag(Player.tag)) {
                    return true;
                }
            }
            return false;
        }
        protected void Initialise(float moveSpeed, float attackDamage, float attackRange, float chaseRange) {
            NextNode = transform.position;
            Player = GameObject.FindGameObjectWithTag("Player").transform;
            GetComponent<Movable>().MoveSpeed = moveSpeed;
            GetComponent<Attacker>().AttackDamage = attackDamage;
            AttackRange = attackRange;
            ChaseRange = chaseRange;
            cachedPosition = transform.position;
            attackerComponent = GetComponent<Attacker>();
            movableComponent = GetComponent<Movable>();
            animatedComponent = GetComponent<Animated>();
        }
        public void RequestPath(Vector3 targetPosition) {
            bIsPathPending = true;
            cachedPosition = targetPosition;
            PathfindingManager.Instance.NewPathRequest(transform.position, targetPosition, path => SetPath(path));
        }

        public bool HasPath() {
            return waypoints.Count > 0;
        }
        public void ClearWaypoints() {
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

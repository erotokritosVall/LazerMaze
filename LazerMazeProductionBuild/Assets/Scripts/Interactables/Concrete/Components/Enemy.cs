using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Interactables.Concrete.Managers;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Pathfinding;

namespace Assets.Scripts.Interactables.Concrete.Components {
    public class Enemy : MonoBehaviour, IUserComponent {
        protected List<AiState> states = new List<AiState>();
        public Transform player { get; private set; }
        public Attackable playerAttackable { get; private set; }
        public ComponentManager componentManager { get; set; }
        public StateController stateController { get; set; }
        public float AttackRange { get; private set; }
        public float ChaseRange { get; private set; }
        private Stack<Vector3> waypoints = new Stack<Vector3>();
        private bool bIsPathPending = false;
        public bool BIsPathPending {
            get { return bIsPathPending; }
        }
        public Vector3 NextNode { get; set; }
        public void SetPath(Stack<Vector3> path) {
            waypoints = path;
            bIsPathPending = false;
        }
        protected void Initialise(float moveSpeed, float attackDamage, float attackRange, float chaseRange) {
            NextNode = transform.position;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerAttackable = player.GetComponent<Attackable>();
            componentManager.movableComponent.MoveSpeed = moveSpeed;
            componentManager.attackerComponent.AttackDamage = attackDamage;
            AttackRange = attackRange;
            ChaseRange = chaseRange;
        }
        public void RequestPath(Vector3 targetPosition) {
            PathfinderHandler.NewPathRequest(transform.position, targetPosition, path => SetPath(path));
            bIsPathPending = true;
        }
        public bool HasPath() {
            return waypoints.Count != 0;
        }
        public void ClearWaypoints() {
            waypoints.Clear();
        }
        public Vector3 GetNextWaypoint() {
            return waypoints.Pop();
        }
        public AiState GetStateByTag(StateTag tag) {
            return states.Find(state => state.stateTag == tag);
        }
        public Vector3 GetMoveDirection(Vector3 target) {
            return (target - transform.position).normalized;
        }
        public bool IsDistanceLessOrEqualThan(Vector3 target, float value) {
            return (transform.position - target).sqrMagnitude <= value;
        }
    }
}

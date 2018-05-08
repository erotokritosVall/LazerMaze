using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.Interactables.Concrete.Controllers {

    /**
     * Component that controls player actions
     */

     [RequireComponent(typeof(AnimatedRanged))]
     [RequireComponent(typeof(AttackableAnimated))]
     [RequireComponent(typeof(AttackerRanged))]
     [RequireComponent(typeof(MovableWithRB))]
    public class PlayerController : UserControlled {

        private const string horizontalAxis = "Horizontal";
        private const string verticalAxis = "Vertical";
        private const string fireButton = "Fire1";
        private bool bShouldShoot = false;
        private Movable movableComponent;
        private Animated animatedComponent;
        private Attacker attackerComponent;

        public static PlayerController Instance { get; private set; }

        private PlayerController() { }

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
            else if (Instance != this) {
                Destroy(this);
            }
            movableComponent = GetComponent<Movable>();
            animatedComponent = GetComponent<Animated>();
            attackerComponent = GetComponent<Attacker>();
        }

        private void Start() {
            movableComponent.MoveSpeed = 5.0f;
        }

        private void Update() {
            attackerComponent.Tick();
            GetInput();
            animatedComponent.SetAnimatorParameters(xInput, zInput);
            if (bShouldShoot) {
                if (attackerComponent.IsAbleToAttack()) {
                    animatedComponent.OnShootEnable();
                    attackerComponent.Attack();
                }
                bShouldShoot = false;
            }
        }

        private void FixedUpdate() {
            movableComponent.MoveDirection = new Vector3(xInput, 0, zInput);
            movableComponent.Move();
        }

        protected override void GetInput() {
            xInput = Input.GetAxisRaw(horizontalAxis);
            zInput = Input.GetAxisRaw(verticalAxis);
            if (Input.GetButtonDown(fireButton)) {
                bShouldShoot = true;
            }
        }
    }
}

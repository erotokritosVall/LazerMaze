using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    [RequireComponent(typeof(MovableBasic))]
    [RequireComponent(typeof(AnimatedRanged))]
    [RequireComponent(typeof(AttackerRanged))]
    [RequireComponent(typeof(AttackableBasic))]
    public class PlayerController : UserControlled {

        private AnimatedRanged animatedRanged;
        private AttackerRanged attackerRanged;
        private AttackableBasic attackableBasic;
        private MovableBasic movableBasic;
        private bool bShouldShoot = false;

        private void Awake() {
            animatedRanged = GetComponent<AnimatedRanged>();
            attackerRanged = GetComponent<AttackerRanged>();
            attackableBasic = GetComponent<AttackableBasic>();
            movableBasic = GetComponent<MovableBasic>();
        }

        private void Update() {
            GetInput();
            animatedRanged.SetAnimatorParameters(XInput, ZInput);
            if (Input.GetMouseButtonDown(0)) {
                bShouldShoot = true;
            }
        }

        private void FixedUpdate() {
            Vector3 moveDirection = new Vector3(XInput, 0, ZInput);
            movableBasic.MoveDirection = moveDirection;
            movableBasic.Move();
        }

        private void LateUpdate() {
            if (bShouldShoot) {
                animatedRanged.OnShootEnable();
                attackerRanged.LaserDirection = new Vector3(animatedRanged.CachedX, 0, animatedRanged.CachedZ);
                attackerRanged.Attack();
                bShouldShoot = false;
            }
        }

        protected override void GetInput() {
            XInput = Input.GetAxisRaw("Horizontal");
            ZInput = Input.GetAxisRaw("Vertical");
        }
    }
}

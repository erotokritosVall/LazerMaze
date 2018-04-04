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

        private void Awake() {
            animatedRanged = GetComponent<AnimatedRanged>();
            attackerRanged = GetComponent<AttackerRanged>();
            attackableBasic = GetComponent<AttackableBasic>();
            movableBasic = GetComponent<MovableBasic>();
        }

        private void Update() {
            GetInput();
        }

        private void FixedUpdate() {
            Vector3 moveDirection = new Vector3(XInput, 0, ZInput);
            movableBasic.Move(moveDirection, 5.0f);
        }

        private void LateUpdate() {
            animatedRanged.SetAnimatorParameters(XInput, ZInput);
        }

        protected override void GetInput() {
            XInput = Input.GetAxisRaw("Horizontal");
            ZInput = Input.GetAxisRaw("Vertical");
        }
    }
}

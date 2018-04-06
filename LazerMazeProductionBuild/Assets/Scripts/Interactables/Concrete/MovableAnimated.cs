namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component that moves and have move animations
     */
    public class MovableAnimated :  MovableBasic {

        protected override void Awake() {
            base.Awake();
        }

        public override void Move(float x, float z) {
            componentManager.animatorComponent.SetAnimatorParameters(MoveDirection.x, MoveDirection.z);
            base.Move(x, z);
        }
    }
}

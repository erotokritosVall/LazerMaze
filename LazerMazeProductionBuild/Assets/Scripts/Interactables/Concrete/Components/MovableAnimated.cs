namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that moves and have move animations
     */
    public class MovableAnimated :  MovableBasic {

        protected override void Awake() {
            base.Awake();
            MoveSpeed = 5.0f;
        }

        public override void Move(float x, float z) {
            componentManager.animatorComponent.SetAnimatorParameters(x, z);
            base.Move(x, z);
        }
    }
}

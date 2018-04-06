namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for objects that are controlled by the player
     */
    public abstract class UserControlled : UserComponent {
        protected float XInput { get; set; }
        protected float ZInput { get; set; }
        protected abstract void GetInput();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {
    public abstract class UserControlled : MonoBehaviour {
        protected float XInput { get; set; }
        protected float ZInput { get; set; }
        protected abstract void GetInput();
    }
}

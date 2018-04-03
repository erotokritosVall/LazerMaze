using Assets.Scripts.Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Managers {
    
    /**
     * Responsible for calling the path handler on each frame , can be set to active/inactive 
     */
    public class PathfinderHandlerManager : MonoBehaviour {
        public bool IsActive { get; set; }

        private void Start() {
            IsActive = true;
        }

        private void LateUpdate() {
            if (IsActive) {
                PathfinderHandler.Tick();
            }
        }
    }
}

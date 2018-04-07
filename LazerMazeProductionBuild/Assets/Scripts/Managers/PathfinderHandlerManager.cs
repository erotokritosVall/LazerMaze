using Assets.Scripts.Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Managers {
    
    /**
     * Responsible for calling the path handler on each frame , can be set to active/inactive 
     */
    public class PathfinderHandlerManager : MonoBehaviour {
        public bool bIsActive { get; set; }

        private void Start() {
            bIsActive = true;
        }

        private void LateUpdate() {
            if (bIsActive) {
                PathfinderHandler.Tick();
            }
        }
    }
}

using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Managers {

    /**
     * Camera following player script
     */

    public class CameraManager : MonoBehaviour {

        private const float yPos = 6.0f;

        private void LateUpdate() {
            transform.position = new Vector3(PlayerController.Instance.transform.position.x, 
                                              yPos, 
                                              PlayerController.Instance.transform.position.z);
        }
    }
}

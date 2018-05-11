using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Managers {

    /**
     * Script for handling the main camera
     */

    public class CameraManager : MonoBehaviour {

        //On awake , scale the camera's rect depending on the current aspect ratio
        private void Awake() {
            float targetAspect = 16.0f / 9.0f;
            float windowAspect = (float)Screen.width / Screen.height;
            float scaleHeight = windowAspect / targetAspect;
            if (scaleHeight < 1.0f) {
                Rect rect = Camera.main.rect;
                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
                Camera.main.rect = rect;
            } else {
                float scalewidth = 1.0f / scaleHeight;
                Rect rect = Camera.main.rect;
                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;
                Camera.main.rect = rect;
            }
        }

        private void LateUpdate() {
            transform.position = new Vector3(PlayerController.Instance.transform.position.x, 
                                              transform.position.y, 
                                              PlayerController.Instance.transform.position.z);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Managers {
    public class CameraManager : MonoBehaviour {
        private Transform player;
        private const float yPos = 4.0f;

        private void Awake() {
            player = GameObject.Find("Brody").transform;
        }

        private void LateUpdate() {
            Vector3 newPosition = new Vector3(player.position.x, yPos, player.position.z);
            transform.position = newPosition;
        }
    }
}

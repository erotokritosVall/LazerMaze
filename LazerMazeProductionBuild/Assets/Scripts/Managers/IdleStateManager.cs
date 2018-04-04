using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Managers {
    public class IdleStateManager : StateMachineBehaviour {
        [SerializeField]
        private Sprite spriteUp;
        [SerializeField]
        private Sprite spriteDown;
        [SerializeField]
        private Sprite spriteRight;

        private Dictionary<Vector2, Sprite> spriteMap = new Dictionary<Vector2, Sprite>();
        [SerializeField]
        private GameObject owner;
        private SpriteRenderer spriteRenderer;
        private Sprite current;

        private void Awake() {
            spriteMap.Add(new Vector2(0, 1), spriteUp);
            spriteMap.Add(new Vector2(0, -1), spriteDown);
            spriteMap.Add(new Vector2(1, 0), spriteRight);
            spriteMap.Add(new Vector2(-1, 0), spriteRight);
            spriteRenderer = owner.GetComponent<SpriteRenderer>();
            current = spriteRenderer.sprite;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
                spriteRenderer.sprite = current;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
            if (spriteRenderer.sprite != current) {
                Debug.Log("spritechanged");
                spriteRenderer.sprite = current;
            }
        }

        public void SetValues(float x, float z) {
            Vector2 key = new Vector2(x, z);
            Debug.Log(key);
            Sprite sprite = spriteMap[key];
            if (current != sprite) {
                current = sprite;
            }
        }
    }
}

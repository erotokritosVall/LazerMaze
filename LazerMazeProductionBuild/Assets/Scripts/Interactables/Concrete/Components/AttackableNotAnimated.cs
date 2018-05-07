using Assets.Scripts.Interactables.Abstract;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that doesn't play hurt animation when hit
     */

    public class AttackableNotAnimated : Attackable {

        private void Awake() {
            MaxLives = currentLives = 2;
            MaxHP = currentHp = 50;
        }

        protected override void CheckHP() {
            if (currentHp <= 0) {
                currentLives--;
                if (currentLives == 0) {
                    GetComponent<CapsuleCollider>().enabled = false;
                    foreach(MonoBehaviour script in GetComponents<MonoBehaviour>()) {
                        script.enabled = false;
                    }
                    StartCoroutine(OnZeroLives());
                } else {
                    currentHp = MaxHP;
                    StartCoroutine(OnLifeLost());
                }
            }
        }

        protected override void Kill() {
            Destroy(gameObject);
        }

        protected override IEnumerator OnLifeLost() {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            const float multiplier = 5.0f;
            for (int i = 0; i < 3; i++) {
                for (float alpha = color.a; alpha > 0; alpha -= Time.deltaTime * multiplier) {
                    color.a = alpha;
                    spriteRenderer.color = color;
                    yield return null;
                }
                for (float alpha = color.a; alpha < 1.0f; alpha += Time.deltaTime * multiplier) {
                    color.a = alpha;
                    spriteRenderer.color = color;
                    yield return null;
                }
            }
        }

        protected override IEnumerator OnZeroLives() {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            const float divisor = 0.5f;
            for (float alpha = color.a; alpha > 0; alpha -= Time.deltaTime * divisor) {
                color.a = alpha;
                spriteRenderer.color = color;
                yield return null;
            }
            Kill();
        }

        public override void OnHit(float damage) {
            currentHp -= damage;
            CheckHP();
        }
    }
}

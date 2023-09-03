using System.Collections;
using UnityEngine;

namespace GameJam {

	public class Bullet : MonoBehaviour {
		[SerializeField] private float timeToHit = 2f;
		[SerializeField] private float speed;
		private Coroutine coroutine;

		public void TrowAtMob(Mob target) {
			coroutine ??= StartCoroutine(Trow(target));
		}

		private IEnumerator Trow(Mob target) {
			if (target != default) {
				float time = 0;
				while (time < timeToHit) {
					Vector3 distance = target.transform.position - transform.position;
					transform.Translate(distance * (time * speed), Space.Self);
					time += Time.fixedDeltaTime;
					yield return null;
				}
				yield return new WaitUntil(() => time >= timeToHit);
				coroutine = null;
				Destroy(gameObject);
			}
		}
	}

}
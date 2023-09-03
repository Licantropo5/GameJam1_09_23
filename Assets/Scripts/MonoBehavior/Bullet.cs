using System.Collections;
using UnityEngine;

namespace GameJam {

	public class Bullet : MonoBehaviour {
		[SerializeField] private float timeToHit = 2f;
		[SerializeField] private float speed;
		private Coroutine coroutine;

		private void Start() {
			Destroy(gameObject, timeToHit);
		}

		public void TrowAtMob(Mob target) {
			coroutine ??= StartCoroutine(Trow(target));
		}

		private IEnumerator Trow(Mob target) {
			float time = 0;
			if (target != null) {
				while (time < timeToHit && target != null) {
					transform.LookAt(transform.position, target.transform.position);
					Vector3 distance = target.transform.position - transform.position;
					transform.Translate(distance * (time * speed), Space.Self);
					time += Time.fixedDeltaTime;
					yield return null;
				}
			}
			yield return new WaitUntil(() => time >= timeToHit);
			coroutine = null;
			Destroy(gameObject);
		}
	}

}
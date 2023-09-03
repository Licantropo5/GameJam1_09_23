using System.Collections;
using GameJam.Buildings;
using UnityEngine;

namespace GameJam {

	public class Slime : Mob {
		public FinalTower target;

		private void Start() {
			target = FindObjectOfType<FinalTower>();
		}

		private float time;

		private void FixedUpdate() {
			if (canMove) {
				Move();
			}
			time += Time.fixedDeltaTime;
		}

		protected override void Move() {
			//this can be a strange behavior we want some monster to have
			//in this case it start fast and it lose speed the more it is near a new path/Curve

			Vector3 position = transform.position;
			var posX = checkPoint.x - position.x;
			var posy = checkPoint.y - position.y;
			position += new Vector3(posX > 1 ? 1f : posX, posy > 1 ? 1f : posy, 0) * (speed * Time.fixedDeltaTime);
			transform.position = position;
		}

		public override void Attack() {
			//this is where the attack start
			StopAllCoroutines();
			target.health -= damage;
			if (target.health <= 0) {
				target.Dead();
			}
			time = 0;
			if (health > 0) {
				StartCoroutine(StartAttack());
			}
		}

		private IEnumerator StartAttack() {
			yield return new WaitUntil(() => time >= fireRate);
			Attack();
		}

		public override void Dead() {
			base.Dead();
			Debug.Log("Death");
			Destroy(gameObject);
			//add some coin to the currency won this round, then delete this monster.
			//Death system, i'll do a controller for this part
		}

	}

}
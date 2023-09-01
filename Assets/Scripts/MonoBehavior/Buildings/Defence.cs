using System;
using UnityEngine;

namespace GameJam.Buildings {

	public class Defence : Building {

		private CircleCollider2D circleCollider;

		private void Start() {
			circleCollider = GetComponent<CircleCollider2D>();
			circleCollider.radius = range;
		}

		private void Attack(Mob mob) {
			mob.health -= damage;
			if (mob.health <= 0) {
				mob.Dead();
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log("EnterMOB");
			if (other.GetComponent<Mob>() is Mob mob) {
				Attack(mob);
			}
		}

		private void OnTriggerStay2D(Collider2D other) {
			if (other.GetComponent<Mob>() is Mob mob) {
				Debug.Log("STAY");
			}
		}
		//Create a coroutine system with a fireRate to damage the mobs
	}

}
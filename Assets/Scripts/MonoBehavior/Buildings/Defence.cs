using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace GameJam.Buildings {

	public class Defence : Building {

		private CircleCollider2D circleCollider;
		private List<Mob> inRadiusMob;
		public float fireRate;

		private float time;

		private void Start() {
			inRadiusMob = new List<Mob>();
			circleCollider = GetComponent<CircleCollider2D>();
			circleCollider.radius = range;
		}

		// private void FixedUpdate() {
		// 	if (inRadiusMob.Count > 0) {
		// 		Attack(inRadiusMob[0]);
		// 		while (expression) {
		// 			
		// 		}
		// 	}
		// }
		private void FixedUpdate() {
			time += Time.deltaTime;
		}

		private void Attack() {
			if (time >= fireRate && inRadiusMob.Count > 0) {
				Mob mob = inRadiusMob[0];
				mob.health -= damage;
				if (mob.health <= 0) {
					mob.Dead();
					inRadiusMob.Remove(mob);
				}
				time = 0;
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log("EnterMOB");
			if (other.GetComponent<Mob>() is Mob mob) {
				inRadiusMob.Add(mob);
			}
		}

		private void OnTriggerStay2D(Collider2D other) {
			if (other.GetComponent<Mob>() is Mob mob) {
				Attack();
			}
		}

		private void OnTriggerExit2D(Collider2D other) {
			if (other.GetComponent<Mob>() is Mob mob) {
				inRadiusMob.Remove(mob);
			}
		}

		//Create a coroutine system with a fireRate to damage the mobs
	}

}
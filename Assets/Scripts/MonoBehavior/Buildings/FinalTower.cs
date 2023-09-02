using System.Collections.Generic;
using GameJam.UI;
using UnityEngine;

namespace GameJam.Buildings {

	public class FinalTower : Building {
		private RoundManager roundManger;
		private CircleCollider2D circleCollider;
		private List<Mob> inRadiusMob;
		public float fireRate;
		[SerializeField] private UpgradeUIFinalTower uiFInalTower;

		private float time;

		#region NativeEvents

		private void Start() {
			roundManger = FindObjectOfType<RoundManager>();
			inRadiusMob = new List<Mob>();
			circleCollider = GetComponent<CircleCollider2D>();
			circleCollider.radius = range;
		}

		private void FixedUpdate() {
			time += Time.deltaTime;
		}

		#endregion

		#region Attack

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

		#endregion

		#region Trigger

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

		#endregion

		#region Upgrade

		public void OnMouseDown() {
			if (roundManger.GetCurrentPhase() == Phase.Upgrade) {
				uiFInalTower.SetShowUpgrade(true);
			}
		}

		private bool IsFireRateMaxedOut() {
			return fireRate <= 1;
		}

		public void UpgradeFireRate() {
			if (!IsFireRateMaxedOut()) {
				fireRate -= 0.1f;
				Debug.Log("FireRate++");
			}
		}

		public void UpgradeDamage() {
			Debug.Log("Upgrade Damage");
			damage += 2;
		}

		#endregion

	}

}
using System.Collections.Generic;
using GameJam.UI;
using UnityEngine;

namespace GameJam.Buildings {

	public class FinalTower : Building {
		public HealthBar healthBar;
		public int maxHealth;
		[SerializeField] private Bullet bullet;
		private RoundManager roundManger;
		private CircleCollider2D circleCollider;
		private List<Mob> inRadiusMob;
		public float fireRate;
		[SerializeField] private UpgradeUIFinalTower uiFinalTower;

		private float time;

		private int upgradeDamage = 4;
		private int upgradeFireRate = 3;
		
		#region NativeEvents

		private void Start() {
			maxHealth = health;
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
				switch (mob.health) {
					case > 0: {
						Bullet instantiate = Instantiate(bullet, transform.position, Quaternion.identity);
						instantiate.TrowAtMob(mob);
						break;
					}
					case <= 0:
						mob.Dead();
						inRadiusMob.Remove(mob);
						break;
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
				uiFinalTower.SetShowUpgrade(true);
			}
		}

		private bool IsFireRateMaxedOut() {
			return fireRate <= 1;
		}

		public void UpgradeFireRate() {
			if (!IsFireRateMaxedOut() && Wallet.HaveEnoughMoney(upgradeFireRate)) {
				fireRate -= 0.1f;
				Wallet.Upgrade(upgradeFireRate);
				Debug.Log("FireRate++");
				upgradeFireRate += 3 * roundManger.GetSurvivedRounds();
			}
		}

		public void UpgradeDamage() {
			if (Wallet.HaveEnoughMoney(upgradeDamage)) {
				Debug.Log("Upgrade Damage");
				damage += 3;
				Wallet.Upgrade(upgradeDamage);
				upgradeDamage += 3 * roundManger.GetSurvivedRounds();
			}
		}

		#endregion

		public override void Dead() {
			roundManger.EndGame();
		}
		
		public int GetUpgradeDamagePrice() {
			return upgradeDamage;
		}

		public int GetUpgradeFireRatePrice() {
			return upgradeFireRate;
		}

	}

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameJam {

	public class MobSpawner : MonoBehaviour{
		[SerializeField] private List<Mob> mobs;
		[SerializeField] private Transform spawnLocation;
		[SerializeField] private float timeNextSpawn;
		private RoundManager roundManager;

		public int numMob;
		private List<Mob> spawnedMonsters;
		public static event Action<Mob> NewMobSpawned; 

		private void Start() {
			roundManager = FindObjectOfType<RoundManager>();
			RoundManager.DefencePhaseStart += CallSpawn;
			spawnedMonsters = new List<Mob>();
		}

		public bool AllMonstersKilled() {
			return spawnedMonsters.Count == 0;
		}

		private void CallSpawn() {
			StartCoroutine(Spawn(numMob));
		}

		private IEnumerator Spawn(int numMobToSpawn) {
			if (Time.timeScale != 0) {
				for (int i = 0; i < numMobToSpawn; i++) {
					int rng = Random.Range(0, mobs.Count);
					Mob mob = Instantiate(mobs[rng], spawnLocation.position, Quaternion.identity);
					NewMobSpawned?.Invoke(mob);
					mob.Death += RemoveMob;
					mob.health += Random.Range(0, roundManager.GetSurvivedRounds());
					mob.speed += Random.Range(0, 2);
					mob.damage += Random.Range(0, roundManager.GetSurvivedRounds());
					spawnedMonsters.Add(mob);
					yield return new WaitForSeconds(timeNextSpawn);
				}
				AddMoreMonsters();
				StopAllCoroutines();
			}
		}
		private void RemoveMob(Mob mob) {
			spawnedMonsters.Remove(mob);
		}

		private void AddMoreMonsters() {
			numMob += 2;
		}
	}

}
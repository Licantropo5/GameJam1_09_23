using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace GameJam {

	public class MobSpawner : MonoBehaviour{
		[SerializeField] private List<Mob> mobs;
		[SerializeField] private Transform spawnLocation;
		[SerializeField] private float timeNextSpawn;

		public int numMob;
		private List<Mob> spawnedMonsters;
		public static event Action<Mob> NewMobSpawned; 

		private IEnumerator Start() {
			RoundManager.DefencePhaseStart += CallSpawn;
			spawnedMonsters = new List<Mob>();
			yield return new WaitForSeconds(0.5f);
		}

		public bool AllMonstersKilled() {
			return spawnedMonsters.Count == 0;
		}

		private void CallSpawn() {
			StartCoroutine(Spawn(numMob));
		}

		private IEnumerator Spawn(int numMobToSpawn) {
			for (int i = 0; i < numMobToSpawn; i++) {
				int rng = Random.Range(0, mobs.Count);
				Mob mob = Instantiate(mobs[rng], spawnLocation.position, Quaternion.identity);
				NewMobSpawned?.Invoke(mob);
				mob.Death += RemoveMob;
				spawnedMonsters.Add(mob);
				yield return new WaitForSeconds(timeNextSpawn);
			}
			AddMoreMonsters();
			StopAllCoroutines();
		}
		private void RemoveMob(Mob mob) {
			spawnedMonsters.Remove(mob);
		}

		private void AddMoreMonsters() {
			numMob += 2;
		}
		
		//Round Manager Pass data based of the round
		
	}

}
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
		public static event Action<Mob> NewMobSpawned; 

		private IEnumerator Start() {
			yield return new WaitForSeconds(0.5f);
			StartCoroutine(Spawn(1));
		}

		private IEnumerator Spawn(int numMobToSpawn) {
			for (int i = 0; i < numMobToSpawn; i++) {
				int rng = Random.Range(0, mobs.Count);
				Mob mob = Instantiate(mobs[rng], spawnLocation.position, Quaternion.identity);
				NewMobSpawned?.Invoke(mob);
				yield return new WaitForSeconds(timeNextSpawn);
			}
		}
		
		//Round Manager Pass data based of the round
		
	}

}
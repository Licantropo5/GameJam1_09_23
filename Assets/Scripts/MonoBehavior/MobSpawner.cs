using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam {

	public class MobSpawner : MonoBehaviour{
		[SerializeField] private List<Mob> mobs;
		[SerializeField] private Transform spawnLocation;
		public static event Action<Mob> NewMobSpawned; 

		private IEnumerator Start() {
			yield return new WaitForSeconds(0.5f);
			Mob mob = Instantiate(mobs[0], spawnLocation.position, Quaternion.identity);
			NewMobSpawned?.Invoke(mob);
		}

	}

}
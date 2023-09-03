using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameJam {

	public class PathController : MonoBehaviour {
		[SerializeField] private List<Path> paths;

		private void Start() {
			paths = new List<Path>();
			paths = FindObjectsOfType<Path>().ToList();
			foreach (Path path in paths) {
				path.HasReachedPath += GiveNextPathToMob;
			}
			paths = paths.OrderByPriority();
			MobSpawner.NewMobSpawned += GetFirstPath;
		}

		private void GetFirstPath(Mob mob) {
			mob.SetNewCheckPoint(paths[0].GetPosition());
		}

		private void GiveNextPathToMob(Mob mob, Path path) {
			int priority = path.GetPriority();
			if (paths.Count > priority + 1) {
				mob.SetNewCheckPoint(paths[priority + 1].GetPosition());
			}
			else {
				path.CallFinalCheckPoint(mob);
			}
		}
	}

}
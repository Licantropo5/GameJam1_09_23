using UnityEngine;

namespace GameJam {

	public class Mob : GameWorld {
		public int health;
		public int damage;
		public float speed;
		public Vector2 checkPoint;

		public void SetNewCheckPoint(Vector2 nextPath) {
			checkPoint = nextPath;
		}
	}

}
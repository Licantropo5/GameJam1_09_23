using System;
using UnityEngine;

namespace GameJam {

	public abstract class Mob : GameWorld {
		public int health;
		public int damage;
		public float speed;
		public Vector2 checkPoint;
		public bool canMove;
		public event Action<Mob> Death;

		protected abstract void Move();

		protected abstract void Attack();

		protected abstract void Dead();
		public void SetNewCheckPoint(Vector2 nextPath) {
			checkPoint = nextPath;
		}
	}

}
using System;
using UnityEngine;

namespace GameJam {

	public abstract class Mob : GameWorld {
		public int health;
		public int damage;
		public float speed;
		public Vector2 checkPoint;
		protected bool canMove = true;
		public event Action<Mob> Death;

		public void SetCanMove(bool canMove) {
			this.canMove = canMove;
		}

		protected abstract void Move();

		protected abstract void Attack();

		public virtual void Dead() {
			Death?.Invoke(this);
		}
		public void SetNewCheckPoint(Vector2 nextPath) {
			checkPoint = nextPath;
		}
	}

}
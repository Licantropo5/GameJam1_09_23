using System;
using UnityEngine;

namespace GameJam {

	public abstract class Mob : GameWorld {
		public int health;
		public int damage;
		public float speed;
		public float fireRate;
		public Vector2 checkPoint;
		public int goldOnDeath;
		protected bool canMove = true;
		public event Action<Mob> Death;

		public void SetCanMove(bool canMove) {
			this.canMove = canMove;
		}

		protected abstract void Move();

		public virtual void Attack() {
			Debug.Log("Virtual");
		}

		public override void Dead() {
			Death?.Invoke(this);
		}
		public void SetNewCheckPoint(Vector2 nextPath) {
			checkPoint = nextPath;
		}
	}

}
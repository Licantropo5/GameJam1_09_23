using UnityEngine;

namespace GameJam {

	public class Slime : Mob {
		
		private void FixedUpdate() {
			if (canMove) {
				Move();
			}
		}

		protected override void Move() {
			//this can be a strange behavior we want some monster to have
			//in this case it start fast and it lose speed the more it is near a new path/Curve
			if (checkPoint != default) {
				Vector3 position = transform.position;
				position += new Vector3(checkPoint.x - position.x, checkPoint.y - position.y, 0) * (speed * Time.fixedDeltaTime);
				transform.position = position;	
			}
		}

		protected override void Attack() {
			//this is where the attack start
		}

		protected override void Dead() {
			//Death system, i'll do a controller for this part
		}

	}

}
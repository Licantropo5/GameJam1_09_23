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
			Vector3 position = transform.position;
			var posX = checkPoint.x - position.x;
			var posy = checkPoint.y - position.y;
			position += new Vector3(posX > 1 ? 1f : posX, posy > 1 ? 1f : posy, 0) * (speed * Time.fixedDeltaTime);
			transform.position = position;
		}

		protected override void Attack() {
			//this is where the attack start
		}

		protected override void Dead() {
			//Death system, i'll do a controller for this part
		}

	}

}
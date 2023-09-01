using UnityEngine;

namespace GameJam {

	public class Slime : Mob {
		
		private void FixedUpdate() {
			Move();
		}

		private void Move() {
			//this can be a strange behavior we want some monster to have
			if (checkPoint != default) {
				Vector3 position = transform.position;
				position += new Vector3(checkPoint.x - position.x, checkPoint.y - position.y, 0) * (speed * Time.fixedDeltaTime);
				transform.position = position;	
			}
		}
	}

}
using GameJam.Buildings;
using UnityEngine;

namespace GameJam {

	public class BaseToPlaceDefences : MonoBehaviour {
		[SerializeField] private Defence defence;
		private void OnMouseDown() {
			var def = Instantiate(defence, transform.position, Quaternion.identity);
			def.transform.position += Vector3.back;
		}
	}

}
	

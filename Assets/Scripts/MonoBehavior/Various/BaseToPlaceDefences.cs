using GameJam.Buildings;
using Unity.Mathematics;
using UnityEngine;

namespace GameJam {

	public class BaseToPlaceDefences : MonoBehaviour {
		[SerializeField] private Defence defence;
		private void OnMouseDown() {
			Instantiate(defence, transform.position, quaternion.identity);
		}
	}

}
	

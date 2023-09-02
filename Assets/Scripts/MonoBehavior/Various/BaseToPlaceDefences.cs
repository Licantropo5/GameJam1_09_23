using GameJam.Buildings;
using UnityEngine;

namespace GameJam {

	public class BaseToPlaceDefences : MonoBehaviour {
		private RoundManager roundManager;
		[SerializeField] private Defence defence;
		private Defence actualDefence;

		private void Start() {
			roundManager = FindObjectOfType<RoundManager>();
		}

		private void OnMouseDown() {
			if (roundManager.GetCurrentPhase() == Phase.Upgrade && actualDefence == null) {
				actualDefence = Instantiate(defence, transform.position, Quaternion.identity);
				actualDefence.transform.position += Vector3.back;
			}
		}
	}

}
	

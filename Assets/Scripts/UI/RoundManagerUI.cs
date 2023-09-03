using TMPro;
using UnityEngine;

namespace GameJam.UI {

	public class RoundManagerUI : MonoBehaviour{
		[SerializeField] private TMP_Text text;
		private RoundManager roundManager;

		private void Start() {
			roundManager = GetComponentInParent<RoundManager>();
		}

		public void ShowPhase() {
			text.text = $"{roundManager.GetCurrentPhase()}";
		}
	}

}
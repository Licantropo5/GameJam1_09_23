using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI {

	public class RoundManagerUI : MonoBehaviour{
		[SerializeField] private TMP_Text text;
		[SerializeField] private Button button;
		private RoundManager roundManager;

		private void Start() {
			roundManager = GetComponentInParent<RoundManager>();
			button.onClick.AddListener(roundManager.FinishUpgradeRoundForcefully);
		}

		public void ShowPhase() {
			text.text = $"{roundManager.GetCurrentPhase()}";
			button.gameObject.SetActive(roundManager.GetCurrentPhase() != Phase.Defence);
		}
	}

}
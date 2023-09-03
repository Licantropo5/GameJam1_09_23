using GameJam.UI;
using UnityEngine;

namespace GameJam.Buildings {

	public class Mine : MonoBehaviour {
		[SerializeField] private int roundToCollectGold;
		[SerializeField] private int gold;
		[SerializeField] private int goldToAdd;
		private MineUI ui;

		private int numberRound;

		private void Start() {
			RoundManager.DefencePhaseEnd += RoundDefended;
			ui = GetComponentInChildren<MineUI>();
			numberRound = 0;
		}

		private void RoundDefended() {
			numberRound += 1;
			if (numberRound >= roundToCollectGold) {
				Wallet.AddGoldToRound(gold);
				ui.ShowText(gold);
				gold += goldToAdd;
				numberRound = 0;
			}
		}
	}
}
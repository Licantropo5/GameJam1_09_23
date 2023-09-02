using UnityEngine;

namespace GameJam.Buildings {

	public class Mine : Building {
		[SerializeField] private int roundToCollectGold;
		[SerializeField] private int gold;

		private int numberRound;

		private void Start() {
			RoundManager.DefencePhaseEnd += RoundDefended;
			numberRound = 0;
		}

		private void RoundDefended() {
			numberRound += 1;
			if (numberRound >= roundToCollectGold) {
				//Give gold
				numberRound = 0;
			}
		}
	}
}
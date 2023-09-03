using GameJam.UI;
using UnityEngine;

namespace GameJam {

	public class Wallet : MonoBehaviour{
		private static int gold;
		private static int goldObtainedInRound;
		private static WalletUI ui;

		private void Start() {
			ui = GetComponentInChildren<WalletUI>();
			ui.ShowGold(gold);
		}

		public static bool HaveEnoughMoney(int amount) {
			return gold >= amount;
		}

		public static void AddGoldToRound(int amount) {
			goldObtainedInRound += amount;
		}

		public static void GetGoldFromRound() {
			gold += goldObtainedInRound;
			ui.ShowGold(gold);
		}

		public static void ResetGoldNewRound() {
			goldObtainedInRound = 0;
		}

		public static void Upgrade(int amount) {
			gold -= amount;
			ui.ShowGold(gold);
		}
		
	}

}
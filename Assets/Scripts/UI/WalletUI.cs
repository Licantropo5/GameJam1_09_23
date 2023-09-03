using TMPro;
using UnityEngine;

namespace GameJam.UI {

	public class WalletUI : MonoBehaviour {
		[SerializeField] private TMP_Text text;

		public void ShowGold(int amount) {
			text.text = $"Gold: {amount}";
		}
	}

}
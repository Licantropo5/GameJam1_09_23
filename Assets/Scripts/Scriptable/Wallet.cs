using UnityEngine;

namespace Scriptable {

	[CreateAssetMenu(fileName = "Wallet", menuName = "Gamejam/Wallet", order = 0)]
	public class Wallet : ScriptableObject {
		public static int gold;

		public bool HaveEnoughMoney(int amount) {
			return gold >= amount;
		}
	}

}
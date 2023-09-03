using System.Collections;
using TMPro;
using UnityEngine;

namespace GameJam.UI {

	public class MineUI : MonoBehaviour {
		[SerializeField] private TMP_Text text;

		public void ShowText(int amount) {
			StartCoroutine(ShowGold(amount));
		}

		private IEnumerator ShowGold(int amount) {
			text.gameObject.SetActive(true);
			text.text = $"{amount}";
			yield return new WaitForSeconds(3f);
			text.gameObject.SetActive(false);
		}
	}

}
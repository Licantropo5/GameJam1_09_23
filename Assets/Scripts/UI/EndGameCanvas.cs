using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameJam.UI {

	public class EndGameCanvas : MonoBehaviour {
		[SerializeField] private Canvas canvas;
		[SerializeField] private TMP_Text endgameT;
		[SerializeField] private Button button;
		private RoundManager roundManager;

		private void Start() {
			roundManager = FindObjectOfType<RoundManager>();
			button.onClick.AddListener(ToMainMenu);
			canvas.gameObject.SetActive(false);
		}

		public void SetUpEndGameCanvas() {
			EndGameText();
		}

		private void ToMainMenu() {
			SceneManager.LoadScene(1);
		}

		private void EndGameText() {
			endgameT.text = $"Congratulations you survived {roundManager.GetSurvivedRounds()} rounds";
		}
	}

}
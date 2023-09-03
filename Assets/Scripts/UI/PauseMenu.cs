using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam.UI {

	public class PauseMenu : MonoBehaviour {
		[SerializeField] private Canvas canvas;
		[SerializeField] private GameObject textForRules;
		private bool isActive = false;
		private bool areRulesShown = false;

		private void Start() {
			canvas.gameObject.SetActive(false);
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				SetCanvas();
			}
		}

		public void Resume() {
			SetCanvas();
		}

		public void Rules() {
			areRulesShown = !areRulesShown;
			textForRules.gameObject.SetActive(areRulesShown);
		}

		public void BackToMenu() {
			//first ever scene will be just a loader
			SceneManager.LoadScene(1);
		}

		private void SetCanvas() {
			isActive = !isActive;
			Time.timeScale = isActive ? 0 : 1;
			canvas.gameObject.SetActive(isActive);
			textForRules.SetActive(false);
		}
	}

}
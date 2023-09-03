using System.Collections;
using GameJam.Buildings;
using TMPro;
using UnityEngine;

namespace GameJam {

	public class BaseToPlaceDefences : MonoBehaviour {
		private RoundManager roundManager;
		[SerializeField] private Defence defence;
		[SerializeField] private TMP_Text text;
		private Defence actualDefence;

		private void Start() {
			roundManager = FindObjectOfType<RoundManager>();
		}

		private void OnMouseDown() {
			if (roundManager.GetCurrentPhase() == Phase.Upgrade && actualDefence == null) {
				actualDefence = Instantiate(defence, transform.position, Quaternion.identity);
				actualDefence.transform.position += Vector3.back;
			}
			else {
				StartCoroutine(ShowErrorText());
			}
		}

		private IEnumerator ShowErrorText() {
			text.text = "Only in Upgrade phase";
			text.color = Color.red;
			yield return new WaitForSeconds(2f);
			text.text = "";
		}
	}

}
	

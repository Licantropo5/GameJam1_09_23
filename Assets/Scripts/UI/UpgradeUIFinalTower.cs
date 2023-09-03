using GameJam.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI {

	public class UpgradeUIFinalTower : MonoBehaviour{
		[SerializeField] private Canvas canvas;
		[SerializeField] private Button btnUpgradeDamage;
		[SerializeField] private Button btnUpgradeFireRate;
		[SerializeField] private Button btnCloseUI;
		[SerializeField] private TMP_Text damageText;
		[SerializeField] private TMP_Text fireRateText;
		[SerializeField] private TMP_Text nextUpgradeTextDamage;
		[SerializeField] private TMP_Text nextUpgradeTextFireRate;
		[SerializeField] private FinalTower finalTower;


		private void Start() {
			btnUpgradeDamage.onClick.AddListener(finalTower.UpgradeDamage);
			btnUpgradeDamage.onClick.AddListener(ShowDamage);
			btnUpgradeFireRate.onClick.AddListener(finalTower.UpgradeFireRate);
			btnUpgradeFireRate.onClick.AddListener(ShowFireRate);
			
			btnCloseUI.onClick.AddListener(CloseMenu);
			CloseMenu();
		}

		private void ShowNextUpgradePriceDamage() {
			nextUpgradeTextDamage.text = $"{finalTower.GetUpgradeDamagePrice()}";
		}
		private void ShowNextUpgradePriceFireRate() {
			nextUpgradeTextFireRate.text = $"{finalTower.GetUpgradeFireRatePrice()}";
		}
		private void ShowDamage() {
			damageText.text = $"Damage\n {finalTower.damage}";
		}
		private void ShowFireRate() {
			fireRateText.text = finalTower.fireRate > 1 ? $"FireRate\n {finalTower.fireRate}" : "FireRate\n Max";
		}

		private void CloseMenu() {
			SetShowUpgrade(false);
		}

		public void SetShowUpgrade(bool set) {
			canvas.gameObject.SetActive(set);
		}
		
	}

}
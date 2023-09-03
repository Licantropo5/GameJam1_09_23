using System;
using GameJam.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI {

	public class UpgradeUIDefence : MonoBehaviour {
		[SerializeField] private Canvas canvas;
		[SerializeField] private Button btnUpgradeDamage;
		[SerializeField] private Button btnUpgradeFireRate;
		[SerializeField] private Button btnCloseUI;
		[SerializeField] private TMP_Text damageText;
		[SerializeField] private TMP_Text fireRateText;
		[SerializeField] private TMP_Text nextUpgradeTextDamage;
		[SerializeField] private TMP_Text nextUpgradeTextFireRate;
		[SerializeField] private Defence defence;

		private void Start() {
			SetShowUpgrade(false);
			btnUpgradeDamage.onClick.AddListener(defence.UpgradeDamage);
			btnUpgradeDamage.onClick.AddListener(ShowDamage);
			btnUpgradeDamage.onClick.AddListener(ShowNextUpgradePriceDamage);
			btnUpgradeFireRate.onClick.AddListener(defence.UpgradeFireRate);
			btnUpgradeFireRate.onClick.AddListener(ShowFireRate);
			btnUpgradeFireRate.onClick.AddListener(ShowNextUpgradePriceFireRate);
			btnCloseUI.onClick.AddListener(CloseMenu);
		}

		private void ShowNextUpgradePriceDamage() {
			nextUpgradeTextDamage.text = $"{defence.GetUpgradeDamagePrice()}";
		}
		private void ShowNextUpgradePriceFireRate() {
			nextUpgradeTextFireRate.text = $"{defence.GetUpgradeFireRatePrice()}";
		}

		private void ShowDamage() {
			damageText.text = $"Damage\n {defence.damage}";
		}

		private void ShowFireRate() {
			fireRateText.text = defence.fireRate > 1 ? $"FireRate\n {defence.fireRate}" : "FireRate\n Max";
		}

		private void CloseMenu() {
			SetShowUpgrade(false);
		}

		public void SetShowUpgrade(bool set) {
			canvas.gameObject.SetActive(set);
		}
	}

}
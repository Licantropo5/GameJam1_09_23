﻿using GameJam.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI {

	public class UpgradeUI : MonoBehaviour {
		private bool showUI;
		[SerializeField] private Canvas canvas;
		[SerializeField] private Button btnUpgradeDamage;
		[SerializeField] private Button btnUpgradeFireRate;
		[SerializeField] private Button btnCloseUI;
		[SerializeField] private TMP_Text damageText;
		[SerializeField] private TMP_Text fireRateText;
		[SerializeField] private Defence defence;

		private void Start() {
			btnUpgradeDamage.onClick.AddListener(defence.UpgradeDamage);
			btnUpgradeDamage.onClick.AddListener(ShowDamage);
			btnUpgradeFireRate.onClick.AddListener(defence.UpgradeFireRate);
			btnUpgradeFireRate.onClick.AddListener(ShowFireRate);
			btnCloseUI.onClick.AddListener(CloseMenu);
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
			showUI = set;
			canvas.gameObject.SetActive(set);
		}
		
		

	}

}
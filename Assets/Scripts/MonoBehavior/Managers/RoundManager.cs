using System;
using System.Collections;
using GameJam.UI;
using UnityEngine;

namespace GameJam {

	public enum Phase {
		Upgrade,
		Defence
	}

	public class RoundManager : MonoBehaviour {
		[SerializeField] private Phase currentPhase;
		[SerializeField] private int upgradePhaseDuration;
		[SerializeField] private MobSpawner spawner;
		private RoundManagerUI ui;
		private int survivedRounds;

		private Coroutine coroutineDefence;
		private Coroutine coroutineUpgrade;

		public static event Action UpgradePhaseStart;
		public static event Action UpgradePhaseEnd;
		public static event Action DefencePhaseStart;
		public static event Action DefencePhaseEnd;

		private void Start() {
			ui = GetComponentInChildren<RoundManagerUI>();
			UpgradePhaseStart += ui.ShowPhase;
			DefencePhaseStart += ui.ShowPhase;
			UpgradePhaseEnd += StartDefence;
			DefencePhaseEnd += StartUpgrade;
			DefencePhaseEnd += AddSurvivedRound;
			DefencePhaseEnd += Wallet.GetGoldFromRound;
			DefencePhaseEnd += Wallet.ResetGoldNewRound;
			StartUpgrade();
		}

		

		private void StartDefence() {
			coroutineDefence = StartCoroutine(StartDefencePhase());
		}

		private void StartUpgrade() {
			coroutineUpgrade = StartCoroutine(StartUpgradePhase());
		}

		private void ChangeCurrentPhase(Phase newPhase) {
			currentPhase = newPhase;
		}

		public Phase GetCurrentPhase() {
			return currentPhase;
		}

		private IEnumerator StartUpgradePhase() {
			coroutineDefence = null;
			//Do things for upgrading with the upgrading manager
			ChangeCurrentPhase(Phase.Upgrade);
			UpgradePhaseStart?.Invoke();
			yield return new WaitForSeconds(upgradePhaseDuration);
			UpgradePhaseEnd?.Invoke();
		}

		//for a button to start the defence immediately.
		public void FinishUpgradeRoundForcefully() {
			StopAllCoroutines();
			UpgradePhaseEnd?.Invoke();
		}

		public void EndGame() {
			StopAllCoroutines();
			Debug.Log("End Game");
		}

		private IEnumerator StartDefencePhase() {
			coroutineUpgrade = null;
			//Here maybe a little delay to put a UI.
			ChangeCurrentPhase(Phase.Defence);
			DefencePhaseStart?.Invoke();
			yield return new WaitUntil(() => spawner.AllMonstersKilled());
			DefencePhaseEnd?.Invoke();
		}

		private void AddSurvivedRound() {
			survivedRounds++;
		}

		public int GetSurvivedRounds() {
			return survivedRounds;
		}
	}

}
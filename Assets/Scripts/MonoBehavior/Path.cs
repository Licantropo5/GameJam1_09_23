﻿using System;
using UnityEngine;

namespace GameJam {

	public class Path : GameWorld {
		private Vector2 position;
		[SerializeField] private int priority;
		public event Action<Mob, Path> HasReachedPath;
		public event Action<Mob> FinalCheckPoint; 


		private void Start() {
			position = transform.position;
			FinalCheckPoint += Test;
		}

		private void Test(Mob mob) {
			Debug.Log("StartAttack");
		}

		public int GetPriority() {
			return priority;
		}

		public Vector2 GetPosition() {
			return position;
		}

		private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log($"Enter Path {name}");
			if (other.gameObject.GetComponent<Mob>() is Mob mob) {
				HasReachedPath?.Invoke(mob, this);
			}
		}

		public void CallFinalCheckPoint(Mob mob) {
			FinalCheckPoint?.Invoke(mob);
		}
	}

}
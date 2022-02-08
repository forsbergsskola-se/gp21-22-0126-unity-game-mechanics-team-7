using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("KillableNPC")) {
			other.gameObject.GetComponent<Death>().isDead = true;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("KillableNPC")) {
			other.gameObject.GetComponent<Death>().isDead = true;
		}
	}
}

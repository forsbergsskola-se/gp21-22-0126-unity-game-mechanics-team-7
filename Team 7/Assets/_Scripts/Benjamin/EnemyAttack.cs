using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<Death>().isDead = true;
		}
	}
}

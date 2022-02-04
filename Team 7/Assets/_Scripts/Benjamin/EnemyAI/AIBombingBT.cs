using System.Collections;
using UnityEngine;

public class AIBombingBT : MonoBehaviour {
	private Transform player;
	private bool canAttack = true;
	[SerializeField] private GameObject bomb;
	[SerializeField] private float attackRange;
	[SerializeField] private float attackDelay;

	
	private void Start() {
		player = GameObject.FindWithTag("Player").transform;
	}
	private void Update() {
		Attack();
	}
	private void Attack() {
		var distanceToTarget = Vector3.Distance(player.position, transform.position);
		if (distanceToTarget < attackRange && canAttack) {
			Instantiate(bomb, transform.position, Quaternion.identity);
			canAttack = false;
			StartCoroutine(DelayAttack());
		}
	}
	
	private IEnumerator DelayAttack() 
	{
		yield return new WaitForSeconds(attackDelay);
		canAttack = true;
	}
}

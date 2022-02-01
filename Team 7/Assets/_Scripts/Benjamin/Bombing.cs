using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : MonoBehaviour {
	private Transform player;
	private bool canAttack = true;
	public GameObject bomb;
	private void Start() {
		player = GameObject.FindWithTag("Player").transform;
	}
	private void Update() {
		Attack();
	}
	private void Attack() {
		var distanceToTarget = Vector3.Distance(player.position, transform.position);
		if (distanceToTarget < 12.5 && canAttack) {
			Instantiate(bomb, transform.position, Quaternion.identity);
			canAttack = false;
			StartCoroutine(DelayAttack());
		}
	}
	
	private IEnumerator DelayAttack() 
	{
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		string tag = other.gameObject.tag;
		Destroy(gameObject);
		if(tag == "Enemy") {
			return;
		}
		if(tag == "Player") {
			Destroy(other.gameObject);
		}
	}
}

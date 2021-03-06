﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBullet : MonoBehaviour {
	[HideInInspector]
	public UnityAction reload;

	void Update() {
		if(transform.position.y > GS.TOP_LIMIT) {
			Destroy(gameObject);
			reload();
		}
	}

	void OnTriggerEnter(Collider other) {
		string tag = other.gameObject.tag;
		if(tag == "Player") {
			return;
		}
		if(tag == "Enemy") {
			other.gameObject.GetComponent<Enemy>().Death();
		} else if(tag == "RedQube") {
			other.gameObject.GetComponent<RedQube>().Collupse();
		} else if(tag == "UFO") {
			other.gameObject.GetComponent<UFO>().Death();
		}

		reload();
		Destroy(gameObject);
	}
}
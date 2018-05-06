﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	private GameObject Bullet;
	[SerializeField]
	private float speed;

	//cached
	private Vector3 moveVector;

	void Start() {
		moveVector = speed*Vector3.right;
	}

	public void MoveHorizontal(int direction) {
		Vector3 planSite = transform.position+direction*moveVector;
		if(planSite.x < GS.LEFT_LIMIT) {
			planSite.x = GS.LEFT_LIMIT;
		} else if(planSite.x > GS.RIGHT_LIMIT) {
			planSite.x = GS.RIGHT_LIMIT;
		}
		transform.position = planSite;
	}

	public void Shoot() {
	}
}

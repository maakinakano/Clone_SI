using System.Collections;
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

	public void MoveHorizontal(float direction) {
		Vector3 planSite = transform.position+direction*moveVector;
		if(planSite.x < GameSetting.LEFT_LIMIT) {
			planSite.x = GameSetting.LEFT_LIMIT;
		} else if(planSite.x > GameSetting.RIGHT_LIMIT) {
			planSite.x = GameSetting.RIGHT_LIMIT;
		}
		transform.position = planSite;
	}

	public void Shoot() {
	}
}

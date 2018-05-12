using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
	[SerializeField]
	private GameObject bulletPrefab;

	//player spec
	[SerializeField]
	private float speed;
	[SerializeField]
	private float bulletSpeed;

	//cached
	private Vector3 moveVector;

	void Start() {
		moveVector = speed*Vector3.right;
	}

	public void MoveHorizontal(int direction, float deltaTime) {
		Vector3 planSite = transform.position+direction*moveVector*deltaTime;
		if(planSite.x < GS.LEFT_LIMIT) {
			planSite.x = GS.LEFT_LIMIT;
		} else if(planSite.x > GS.RIGHT_LIMIT) {
			planSite.x = GS.RIGHT_LIMIT;
		}
		transform.position = planSite;
	}

	public void Shoot(UnityAction reload) {
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody>().velocity = bulletSpeed*Vector3.up;
		bullet.GetComponent<PlayerBullet>().reload = reload;
	}
}

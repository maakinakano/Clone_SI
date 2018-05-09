using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private GameObject motion0;
	[SerializeField]
	private GameObject motion1;
	[SerializeField]
	private GameObject bulletPrefab;
	[SerializeField]
	public int score;
	[HideInInspector]
	public UnityAction<int> reachEdge;
	[HideInInspector]
	public UnityAction<int> addScore;

	public void MoveHorizontal(int direction) {
		transform.position += direction*GS.ENEMY_SPEED;
		if(transform.position.x < GS.LEFT_LIMIT) {
			reachEdge(GS.LEFT);
		} else if(transform.position.x > GS.RIGHT_LIMIT) {
			reachEdge(GS.RIGHT);
		}
		FlipMotion();
	}

	public void MoveDown() {
		transform.position += GS.ENEMY_SPEED_DOWN;
	}

	private void FlipMotion() {
		motion0.SetActive(!motion0.activeSelf);
		motion1.SetActive(!motion1.activeSelf);
	}

	public void ShootEnemy() {
		GameObject bullet = Instantiate(bulletPrefab, transform.position+GS.ENEMY_MAZZLE_OFFSET, Quaternion.identity);
		bullet.GetComponent<Rigidbody>().velocity = GS.ENEMY_BULLET_SPEED*Vector3.down;
	}

	public void Death() {
		addScore(score);
		Destroy(gameObject);
	}
}

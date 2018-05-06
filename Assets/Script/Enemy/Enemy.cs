using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private GameObject motion0;
	[SerializeField]
	private GameObject motion1;
	[HideInInspector]
	public UnityAction<int> reachEdge;

	public void MoveHorizontal(int direction) {
		transform.position += direction*GS.ENEMY_SPEED;
		if(transform.position.x < GS.LEFT_LIMIT) {
			reachEdge(GS.LEFT);
		} else if(transform.position.x > GS.RIGHT_LIMIT) {
			reachEdge(GS.RIGHT);
		}
		flipMotion();
	}

	public void MoveDown() {
		transform.position += GS.ENEMY_SPEED_DOWN;
	}

	private void flipMotion() {
		motion0.SetActive(!motion0.activeSelf);
		motion1.SetActive(!motion1.activeSelf);
	}
}

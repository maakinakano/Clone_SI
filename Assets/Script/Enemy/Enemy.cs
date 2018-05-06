using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private GameObject motion0;
	[SerializeField]
	private GameObject motion1;

	public void MoveHorizontal(int direction) {
		Vector3 planSite = transform.position+direction*GS.ENEMY_SPEED;
		if(planSite.x < GS.LEFT_LIMIT) {
			planSite.x = GS.LEFT_LIMIT;
		} else if(planSite.x > GS.RIGHT_LIMIT) {
			planSite.x = GS.RIGHT_LIMIT;
		}
		transform.position = planSite;
		flipMotion();
	}

	private void flipMotion() {
		motion0.SetActive(!motion0.activeSelf);
		motion1.SetActive(!motion1.activeSelf);
	}
}

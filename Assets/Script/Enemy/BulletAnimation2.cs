using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation2 : MonoBehaviour {

	[SerializeField]
	private GameObject bar;

	void Update () {
		Vector3 barPos = bar.transform.position;
		barPos += Time.deltaTime*Vector3.up;
		if(barPos.y > transform.position.y+0.2f) {
			barPos.y = transform.position.y-0.2f;
		}
		bar.transform.position = barPos;
	}
}

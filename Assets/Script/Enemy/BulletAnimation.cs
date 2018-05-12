using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour {


	void Update () {
		transform.Rotate(0f, 1000f*Time.deltaTime, 0f);
	}
}

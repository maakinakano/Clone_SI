using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedQube : MonoBehaviour {
	[HideInInspector]
	public int x;
	[HideInInspector]
	public int y;
	[HideInInspector]
	public UnityAction<int, int> onCollupse;

	public void Collupse() {
		onCollupse(x, y);
		Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField]
	private Text scoreUI;

	public void ReflectScore(int score) {
		scoreUI.text = ""+score;
	}
}

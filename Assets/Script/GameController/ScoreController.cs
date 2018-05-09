using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour {

	private int _score;
	[HideInInspector]
	public UnityAction<int> refrect;

	public void addScore(int score) {
		_score += score;
		refrect(_score);
	}
}

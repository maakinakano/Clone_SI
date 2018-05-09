using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private UIController uiCon;
	private ScoreController scoreCon;
	private EnemyController enemyCon;

	void Start() {
		uiCon = GetComponent<UIController>();
		scoreCon = GetComponent<ScoreController>();
		enemyCon = GetComponent<EnemyController>();

		scoreCon.refrect = (x) => {
			uiCon.ReflectScore(x);
		};
		enemyCon.Initalize();
		enemyCon.Spawn((score) => {
			scoreCon.addScore(score);
		});
	}
}

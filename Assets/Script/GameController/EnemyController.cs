using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemyKind = new GameObject[GS.CORPSE_HEIGHT];

	private EnemyCorpse enemyCorpse;

	//enemy move
	private float moveCoolTime;
	private float moveTimer;
	private int direction;
	private bool willDown;

	void Start () {
		Initalize();
	}

	void Update() {
		moveTimer -= Time.deltaTime;
		if(moveTimer < 0f) {
			MoveEnemy();
		}
	}

	//for enemy move modules
	private void MoveEnemy() {
		moveTimer += moveCoolTime;
		if(willDown) {
			willDown = false;
			enemyCorpse.MoveDown();
		} else {
			enemyCorpse.MoveHorizontal(direction);
		}
	}

	public void ReachEdge(int edge) {
		direction = -edge;
		willDown = true;
	}

	//for init modules
	public void Initalize() {
		Spawn();
		moveCoolTime = 1f;
		direction = GS.RIGHT;
		willDown = false;
	}

	private void Spawn() {
		enemyCorpse = new EnemyCorpse(enemyKind, ReachEdge);
	}
}

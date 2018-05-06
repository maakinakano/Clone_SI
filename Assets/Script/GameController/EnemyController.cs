using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemyKind = new GameObject[GS.CORPSE_HEIGHT];

	private EnemyCorpse enemyCorpse;
	private float moveCoolTime;
	private float moveTimer;

	void Start () {
		Initalize();
	}

	void Update() {
		moveTimer -= Time.deltaTime;
		if(moveTimer < 0f) {
			MoveHorizontal();
		}
	}

	private void MoveHorizontal() {
		moveTimer += moveCoolTime;
		enemyCorpse.MoveHorizontal(GS.RIGHT);
	}

	//for init modules
	public void Initalize() {
		Spawn();
		moveCoolTime = 1f;
	}

	private void Spawn() {
		enemyCorpse = new EnemyCorpse(enemyKind);
	}
}

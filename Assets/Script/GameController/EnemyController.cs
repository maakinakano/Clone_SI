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
	//enemy attack
	private float attackTimer;
	private int[] aliveEnemy = new int[GS.CORPSE_WIDTH];

	void Start () {
		Initalize();
	}

	void Update() {
		moveTimer -= Time.deltaTime;
		attackTimer -= Time.deltaTime;
		if(moveTimer < 0f) {
			MoveEnemy();
		}
		if(attackTimer < 0f) {
			ShootEnemy();
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

	//for enemy attack modules
	public void ShootEnemy() {
		attackTimer += GS.ATTACK_COOL_TIME;
		enemyCorpse.GetAliveEnemyPos(aliveEnemy);
		int count = 0;
		foreach(int pos in aliveEnemy) {
			if(pos != GS.CORPSE_HEIGHT) {
				count++;
			}
		}
		count = Random.Range(0, count);
		for(int i = 0; i < GS.CORPSE_WIDTH; i++) {
			if(aliveEnemy[i] == GS.CORPSE_HEIGHT) {
				continue;
			}
			if(count == 0) {
				enemyCorpse.ShootEnemy(i, aliveEnemy[i]);
				break;
			}
			count--;
		}
	}

	//for init modules
	public void Initalize() {
		Spawn();
		direction = GS.RIGHT;
		willDown = false;
		moveCoolTime = GS.MOVE_COOL_TIME;
		moveTimer = moveCoolTime;
		attackTimer = GS.ATTACK_COOL_TIME;
	}

	private void Spawn() {
		enemyCorpse = new EnemyCorpse(enemyKind, ReachEdge);
	}
}

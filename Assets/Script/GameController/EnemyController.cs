using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemyKind = new GameObject[GS.CORPSE_HEIGHT];

	private EnemyCorpse enemyCorpse;
	[HideInInspector]
	public UnityAction<int> addScore;

	//enemy move
	private float moveCoolTime;
	private float moveTimer;
	private int direction;
	private bool willDown;
	private bool enemyFuneral;
	//enemy attack
	private float attackTimer;
	private int[] aliveEnemy = new int[GS.CORPSE_WIDTH];
	//ufo
	[SerializeField]
	private GameObject ufo;
	private float ufoTimer;

	void Update() {
		if(enemyFuneral){return;}
		moveTimer -= Time.deltaTime;
		attackTimer -= Time.deltaTime;
		ufoTimer -= Time.deltaTime;
		if(moveTimer < 0f) {
			MoveEnemy();
		}
		if(attackTimer < 0f) {
			ShootEnemy();
		}
		if(ufoTimer < 0f) {
			UFOSpawn();
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

	//for UFO spawn module
	public void UFOSpawn() {
		ufoTimer += GS.UFO_SPAWN_COOL_TIME+Random.Range(0f, GS.UFO_SPAWN_COOL_TIME);
		int dir = (Random.Range(0, 2) == 0) ? 1 : -1;
		GameObject ufoObject = Instantiate(ufo, new Vector3(dir*GS.RIGHT_LIMIT, 3.8f, 0), Quaternion.identity);
		ufoObject.GetComponent<UFO>().addScore = addScore;
		ufoObject.GetComponent<Rigidbody>().velocity = dir*Vector3.left*3.0f;
	}

	//for init modules
	public void Initalize() {
		direction = GS.RIGHT;
		willDown = false;
		moveCoolTime = GS.MOVE_COOL_TIME;
		moveTimer = moveCoolTime;
		attackTimer = GS.ATTACK_COOL_TIME;
		ufoTimer = GS.UFO_SPAWN_COOL_TIME;
	}

	public void Spawn() {
		enemyCorpse = new EnemyCorpse(enemyKind, ReachEdge, (x)=>{
			//敵が死ぬと少し移動を止める
			enemyFuneral = true;
			addScore(x);
		},onEnemyDead);
	}

	public void onEnemyDead() {
		enemyFuneral = false;
	}
}

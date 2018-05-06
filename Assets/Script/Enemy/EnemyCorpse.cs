using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCorpse{
	private EnemyLine[] enemyLine;

	public EnemyCorpse(GameObject[] enemyKind, UnityAction<int> reachEdge) {
		enemyLine = new EnemyLine[GS.CORPSE_HEIGHT];
		for(int i = 0; i < GS.CORPSE_HEIGHT; i++) {
			float y = GS.ENEMY_HEIGHT*(i-GS.CORPSE_HEIGHT/2);
			enemyLine[i] = new EnemyLine(enemyKind[i], y, reachEdge);

		}
	}

	//for enemy move modules
	public void MoveHorizontal(int direction) {
		for(int i = 0; i < GS.CORPSE_HEIGHT; i++) {
			enemyLine[i].MoveHorizontal(direction);
		}
	}

	public void MoveDown() {
		for(int i = 0; i < GS.CORPSE_HEIGHT; i++) {
			enemyLine[i].MoveDown();
		}
	}

	//for enemy attack modules
	public void ShootEnemy(int i, int j) {
		enemyLine[j].ShootEnemy(i);
	}
	//副作用で生きてるEnemyの位置を返す
	public void GetAliveEnemyPos(int[] aliveEnemy) {
		for(int i = 0; i < GS.CORPSE_WIDTH; i++) {
			aliveEnemy[i] = GS.CORPSE_HEIGHT;
		}
		for(int j = GS.CORPSE_HEIGHT-1; j >= 0; j--) {
			int posBit = enemyLine[j].GetAliveEnemyPos();
			for(int i = 0; i < GS.CORPSE_WIDTH; i++) {
				//一番左が最上位bitなので反転する
				if((posBit & (1 << (GS.CORPSE_WIDTH-i-1))) != 0) {
					aliveEnemy[i] = j;
				}
			}
		}
	}
}

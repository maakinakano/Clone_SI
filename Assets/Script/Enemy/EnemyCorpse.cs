using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCorpse{
	private EnemyLine[] enemyLine;

	public EnemyCorpse(GameObject[] enemyKind) {
		enemyLine = new EnemyLine[GS.CORPSE_HEIGHT];
		for(int i = 0; i < GS.CORPSE_HEIGHT; i++) {
			float y = GS.ENEMY_HEIGHT*(i-GS.CORPSE_HEIGHT/2);
			enemyLine[i] = new EnemyLine(enemyKind[i], y);
		}
	}

	public void MoveHorizontal(int direction) {
		for(int i = 0; i < GS.CORPSE_HEIGHT; i++) {
			enemyLine[i].MoveHorizontal(direction);
		}
	}
}

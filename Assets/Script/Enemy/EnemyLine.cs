﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLine {
	private Enemy[] enemies;

	public EnemyLine(GameObject enemyPrefab, float y, UnityAction<int> reachEdge) {
		enemies = new Enemy[GS.CORPSE_WIDTH];
		GameObject enemyParent = GameObject.Find("Enemies");
		for(int i = 0; i < GS.CORPSE_WIDTH; i++) {
			float x = GS.ENEMY_WIDTH*(i-GS.CORPSE_WIDTH/2);
			GameObject enemy = GameObject.Instantiate(enemyPrefab, new Vector3(x, y, 0f), Quaternion.identity);
			enemy.transform.parent = enemyParent.transform;
			enemies[i] = enemy.GetComponent<Enemy>();
			enemies[i].reachEdge = reachEdge;
		}
	}

	public void MoveHorizontal(int direction) {
		for(int i = 0; i < GS.CORPSE_WIDTH; i++) {
			if(enemies[i] == null) {
				continue;
			}
			enemies[i].MoveHorizontal(direction);
		}
	}

	public void MoveDown() {
		for(int i = 0; i < GS.CORPSE_WIDTH; i++) {
			if(enemies[i] == null) {
				continue;
			}
			enemies[i].MoveDown();
		}
	}
}

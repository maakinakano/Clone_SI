using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tochka : MonoBehaviour {
	[SerializeField]
	private GameObject redQube;

	private GameObject[,] qubes;
	private float collupseCoolTime;

	private int[,] tochkaMap = {
		{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
		{ 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
		{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
		{ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
	};

	private int[,] collupseMap = {
		{ 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
		{ 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1 },
		{ 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0 },
		{ 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1 },
		{ 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0 },
		{ 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1 },
	};

	//cached
	private int tochkaH;
	private int tochkaW;

	void Start () {
		tochkaH = tochkaMap.GetLength(0);
		tochkaW = tochkaMap.GetLength(1);
		qubes = new GameObject[tochkaH, tochkaW];
		for(int y = 0; y < tochkaH; y++) {
			for(int x = 0; x < tochkaW; x++) {
				if(tochkaMap[y, x] == 0) {continue;}
				Vector3 pos = transform.position;
				pos.x += GS.RED_QUBE_SIZE*(x-tochkaW/2);
				pos.y += GS.RED_QUBE_SIZE*(tochkaH/2-y);
				qubes[y,x] = Instantiate(redQube, pos, Quaternion.identity);
				qubes[y,x].transform.parent = transform;
				RedQube redQ = qubes[y,x].GetComponent<RedQube>();
				redQ.x = x;
				redQ.y = y;
				redQ.onCollupse = CollupseAction;
			}
		}
	}

	void Update() {
		collupseCoolTime -= Time.deltaTime;
	}

	private void CollupseAction(int x, int y) {
		if(collupseCoolTime > 0)
			return;
		collupseCoolTime = 0.1f;
		int mapH = collupseMap.GetLength(0);
		int mapW = collupseMap.GetLength(1);
		for(int i = 0; i < mapW; i++) {
			for(int j = 0; j < mapH; j++) {
				if(collupseMap[j, i] == 0) {continue;}
				int cx = x+i-mapW/2;
				int cy = y+j;
				if(cx < 0 || cx >= tochkaW || cy < 0 || cy >= tochkaH) {continue;}
				if(qubes[cy, cx] == null) {continue;}
				Destroy(qubes[cy, cx]);
			}
		}
	}
}

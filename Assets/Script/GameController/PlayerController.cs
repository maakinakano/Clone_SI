using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private GameObject playerPrefab;
	private Player player;
	[SerializeField]
	private Transform respawnPoint;

	void Start () {
		Respawn();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			player.MoveHorizontal(GS.LEFT);
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			player.MoveHorizontal(GS.RIGHT);
		} else if(Input.GetKey(KeyCode.Space)) {
			player.Shoot();
		}
	}

	void Respawn() {
		player = Instantiate(playerPrefab, respawnPoint).GetComponent<Player>();
	}
}

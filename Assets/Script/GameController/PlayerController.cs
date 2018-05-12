using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private GameObject playerPrefab;
	private Player player;
	[SerializeField]
	private Transform respawnPoint;

	private bool canShoot;

	void Start () {
		Respawn();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			player.MoveHorizontal(GS.LEFT, Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			player.MoveHorizontal(GS.RIGHT, Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.Space) && canShoot) {
			canShoot = false;
			player.Shoot(()=>{canShoot = true;});
		}
	}

	void Respawn() {
		player = Instantiate(playerPrefab, respawnPoint).GetComponent<Player>();
		canShoot = true;
	}
}

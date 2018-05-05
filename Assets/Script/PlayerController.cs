using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private GameObject playerPrefab;
	private Player player;
	[SerializeField]
	private Transform respawnPoint;

	private readonly float RIGHT = 1F;
	private readonly float LEFT = -1F;

	void Start () {
		Respawn();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			player.MoveHorizontal(LEFT);
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			player.MoveHorizontal(RIGHT);
		} else if(Input.GetKey(KeyCode.Space)) {
			player.Shoot();
		}
	}

	void Respawn() {
		player = Instantiate(playerPrefab, respawnPoint).GetComponent<Player>();
	}
}

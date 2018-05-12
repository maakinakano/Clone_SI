using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UFO : MonoBehaviour {

	[SerializeField]
	private GameObject ufo;
	[SerializeField]
	private GameObject clush;
	[SerializeField]
	private GameObject scoreUI;
	[SerializeField]
	private Texture[] scoreTexture = new Texture[4];
	[HideInInspector]
	public UnityAction<int> addScore;

	private int[] score = { 50, 100, 150, 300 };

	public void Update() {
		float x = transform.position.x;
		if(x < GS.LEFT_LIMIT || x > GS.RIGHT_LIMIT) {
			Destroy(gameObject);
		}
	}

	public void Death() {
		ufo.SetActive(false);
		clush.SetActive(true);
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		StartCoroutine("destroyCoroutine");
	}
	private IEnumerator destroyCoroutine() {
		yield return new WaitForSeconds(0.1f);
		int rand = Random.Range(0, 4);
		addScore(score[rand]);
		clush.SetActive(false);
		scoreUI.GetComponent<Renderer>().material.SetTexture("_MainTex", scoreTexture[rand]);
		scoreUI.SetActive(true);
		yield return new WaitForSeconds(0.25f);
		Destroy(gameObject);
	}

}

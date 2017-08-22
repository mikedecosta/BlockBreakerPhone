using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;
	
	void Start() {
		this.levelManager = FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (!collider.gameObject.CompareTag("Ball")) {
			return;
		}
		LevelManager.extraLives--;
		if (LevelManager.extraLives <= -1) {
			levelManager.LoadLevel("Lose");
		} else {
			collider.gameObject.GetComponent<Ball>().reset();
		}
	}
}

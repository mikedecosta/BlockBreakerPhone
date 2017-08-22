using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour, IComparable<Brick> {
	public Color[] stages;
	private int timesHit;
	private static int numOfBricksInScene;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		if(this.tag != "Unbreakable") {
			Brick.numOfBricksInScene++;
		}
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void resetBrickCount() {
		Brick.numOfBricksInScene = 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		int multiplyer = getMultiplyer();
		Debug.Log (multiplyer);
		if (stages.Length > 0 && stages.Length > timesHit) {
			Color c = this.stages[this.timesHit];
			gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r,c.g,c.b);
			this.timesHit++;
			LevelManager.AddToScore(3 * multiplyer);
		} else {
			if (this.tag != "Unbreakable") {
				Brick.numOfBricksInScene--;
				Destroy(this.gameObject);
				LevelManager.AddToScore(5 * multiplyer);
				if (Brick.numOfBricksInScene <= 0) {
					levelManager.LoadNextLevel();
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (this.tag == "0-Hit") {
			int multiplyer = getMultiplyer();
			Debug.Log (multiplyer);
			Brick.numOfBricksInScene--;
			Destroy(this.gameObject);
			LevelManager.AddToScore(5 * multiplyer);
			if (Brick.numOfBricksInScene <= 0) {
				levelManager.LoadNextLevel();
			}
		}
	}
	
	private int getMultiplyer() {
		int val = UnityEngine.Random.Range(1, 9999);
		if (val < 5001) {
			return 1;
		} else if (val < 7501) {
			return 2;
		} else if (val < 8501) {
			return 3;
		} else if (val < 9001) {
			return 4;
		} else if (val < 9251) {
			return 5;
		} else if (val < 9501) {
			return 6;
		} else if ( val < 9751) {
			return 7;
		} else if ( val < 9901) {
			return 8;
		} else if ( val < 9991) {
			return 9;
		} else if (val < 9999) {
			return 10;
		} else if (val == 9999) {
			return 20;
		} else {
			return 1;
		}
	}
	
	public int CompareTo(Brick other) {
		if (this.transform.position.x < other.transform.position.x) {
			return -1;
		}
		if (this.transform.position.x > other.transform.position.x) {
			return 1;
		}
		return 0;
	}
}

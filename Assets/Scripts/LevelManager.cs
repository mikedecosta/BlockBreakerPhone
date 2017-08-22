using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	static LevelManager instance;
	public static int score;
	public static int extraLives;
	private static int nextExtraLife = 500;
	private static int extraLifeIncrement = 500;
	
	public static void AddToScore(int addTo) {
		score += addTo;
		if (score >= nextExtraLife) {
			extraLives++;
			nextExtraLife += extraLifeIncrement;
		}
	}
	
	public void LoadLevel(string name) {
		if(name == "Level_01") {
			score = 0;
			extraLives = 3;
		}
		Application.LoadLevel(name);
		if (FindObjectsOfType<Brick>().Length > 0) {
			FindObjectsOfType<Brick>()[0].resetBrickCount();
		}
	}

	public void QuitRequest() {
		Debug.Log ("Request to quit");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}

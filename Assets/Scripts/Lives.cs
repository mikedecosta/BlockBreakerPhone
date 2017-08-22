using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {
	public Text text;
	
	// Update is called once per frame
	void Update () {
		this.text.text = LevelManager.extraLives.ToString();
	}
}

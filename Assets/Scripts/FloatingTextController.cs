using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour {
	private static FloatingText floatingTextPrefab;
	private static GameObject canvas;
	
	public static void Initilize() {
		floatingTextPrefab = Resources.Load<FloatingText>("Prefabs/PopupParent");
		canvas = GameObject.Find("Canvas");
	}
	
	public static void CreateFloatingText(string text, Color c, Transform position) {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(position.position);
		FloatingText instance = Instantiate(floatingTextPrefab);
		instance.transform.SetParent(canvas.transform, false);
		instance.transform.position = screenPosition;
		instance.SetText(text);
		instance.SetColor(c);
	}
}

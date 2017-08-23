using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
	public Animator animator;
	
	void Start() {
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
		float destroyAfterTime = clipInfo.Length > 0 ? clipInfo[0].clip.length : 0.45f;
		Destroy(gameObject, destroyAfterTime);
	}
	
	public void SetText(string text) {
		animator.GetComponent<Text>().text = text;
	}
	
	public void SetColor(Color c) {
		animator.GetComponent<Text>().color = c;
	}
}

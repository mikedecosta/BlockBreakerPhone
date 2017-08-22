using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public float ClAMP_OFFSET = 0.9f;
	public int BLOCK_SIZE = 8;
	
	public bool playForMe;

	private Ball ball;
	private Wall leftWall;
	private Wall rightWall;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball>();
		Wall[] walls = FindObjectsOfType<Wall>();
		foreach (Wall wall in walls) {
			if (wall.isLeft) {
				leftWall = wall;
			} else {
				rightWall = wall;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = getPaddlePosition();
	}
	
	Vector3 getPaddlePosition() {
		return new Vector3(
			getXPaddlePosition(),
			this.transform.position.y,
			this.transform.position.z
		);
	}
	
	float getXPaddlePosition() {
		if (playForMe) {
			return Mathf.Clamp(this.ball.transform.position.x, getLeftClamp(), getRightClamp());
		}
		
		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * BLOCK_SIZE;
		return Mathf.Clamp(mousePositionInBlocks, getLeftClamp(), getRightClamp());
	}
	
	float getLeftClamp() {
		return leftWall.transform.position.x + ClAMP_OFFSET;
	}
	
	float getRightClamp() {
		return rightWall.transform.position.x - ClAMP_OFFSET;
	}
}

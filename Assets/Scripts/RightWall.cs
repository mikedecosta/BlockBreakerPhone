using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RightWall : MonoBehaviour {
	public float speed;
	const float BRICK_OFFSET = 1.5f;
	private List<Brick> bricks;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		this.transform.position = Vector3.MoveTowards(transform.position, getNewPosition(), step);
	}
	
	Vector2 getNewPosition() {
		return new Vector2(
			Mathf.Clamp(getRightMostBrick() + BRICK_OFFSET, 0f, 9f),
			this.transform.position.y
		);
	}
	
	float getRightMostBrick() {
		this.bricks = new List<Brick>(FindObjectsOfType<Brick>());
		if (this.bricks.Count == 0) {
			return Screen.width - BRICK_OFFSET;
		}
		this.bricks.Sort();
		this.bricks.Reverse();
		return this.bricks[0].transform.position.x;
	}
}

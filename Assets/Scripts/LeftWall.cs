using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftWall : MonoBehaviour {
	public float speed;
	public float leftClamp = 0f;
	public float rightClamp = 9f;
	
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
			Mathf.Clamp(getLeftMostBrick() - BRICK_OFFSET, leftClamp, rightClamp),
			this.transform.position.y
		);
	}
	
	float getLeftMostBrick() {
		this.bricks = new List<Brick>(FindObjectsOfType<Brick>());
		if (bricks.Count == 0) {
			return BRICK_OFFSET;
		}
		this.bricks.Sort();
		return this.bricks[0].transform.position.x;
	}

}

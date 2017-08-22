using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
	public float speed = 0.5f;
	public float leftClamp = 0f;
	public float rightClamp = 8f;
	public bool isLeft;
	
	const float BRICK_OFFSET = 1.5f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		this.transform.position = Vector3.MoveTowards(transform.position, getNewPosition(), step);
	}
	
	Vector2 getNewPosition() {
		float mostBrick = isLeft ? getLeftMostBrick() : getRightMostBrick();
		float offset = isLeft ? -BRICK_OFFSET : BRICK_OFFSET;
		return new Vector2(
			Mathf.Clamp(mostBrick + offset, leftClamp, rightClamp),
			this.transform.position.y
		);
	}
	
	float getLeftMostBrick() {
		List<Brick> bricks = new List<Brick>(FindObjectsOfType<Brick>());
		if (bricks.Count == 0) {
			return BRICK_OFFSET;
		}
		bricks.Sort();
		return bricks[0].transform.position.x;
	}
	
	float getRightMostBrick() {
		List<Brick> bricks = new List<Brick>(FindObjectsOfType<Brick>());
		if (bricks.Count == 0) {
			return Screen.width - BRICK_OFFSET;
		}
		bricks.Sort();
		bricks.Reverse();
		return bricks[0].transform.position.x;
	}
	
}

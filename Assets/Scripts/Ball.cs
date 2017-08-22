using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private bool ballInPlay;
	private Paddle paddle;
	
	public void reset() {
		this.ballInPlay = false;
		this.transform.position = this.paddle.transform.position + new Vector3(0f,0.4f,0f);
	}
	
	// Use this for initialization
	void Start () {
		this.ballInPlay = false;
		this.paddle = FindObjectOfType<Paddle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ballInPlay) {
			if(Input.GetMouseButtonUp(0)) {
				Vector2 velocity = new Vector2(.5f, 10f);
				gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
				this.ballInPlay = true;
			}
			
			gameObject.transform.position = this.paddle.transform.position + new Vector3(0f,0.4f,0f);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 velocityBoost = new Vector2(
			getNewXVelocityBoost(gameObject.GetComponent<Rigidbody2D>().velocity.x),
			getNewYVelocityBoost(gameObject.GetComponent<Rigidbody2D>().velocity.y)
		);
		
		gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity + velocityBoost;
		LevelManager.AddToScore(1);
	}
	
	float getNewYVelocityBoost(float currentYVelocity) {
		if (ballGoingTooSlowDown(currentYVelocity) || ballGoingTooFastUp(currentYVelocity)) {
			return Random.Range(-2f, -1f);
		} else if (ballGoingTooSlowUp(currentYVelocity) || ballGoingTooFastDown(currentYVelocity)) {
			return Random.Range(1f, 2f);
		} 
		
		return 0f;
	}
	
	float getNewXVelocityBoost(float currentXVelocity) {
		if (ballGoingTooSlowLeft(currentXVelocity) || ballGoingTooFastRight(currentXVelocity)) {
			return Random.Range(-1.5f, -0.5f);
		} else if (ballGoingTooSlowRight(currentXVelocity) || ballGoingTooFastLeft(currentXVelocity)) {
			return Random.Range(0.5f, 1.5f);
		} 
		
		return 0f;
	}
	
	// Y Velocity Tests
	bool ballGoingTooSlowDown(float currentYVelocity) {
		return currentYVelocity <= 0f && currentYVelocity >= -5f;
	}
	
	bool ballGoingTooSlowUp(float currentYVelocity) {
		return currentYVelocity <= 5f && currentYVelocity >= 0f;
	}
	
	bool ballGoingTooFastDown(float currentYVelocity) {
		return currentYVelocity < -16f;
	}
	
	bool ballGoingTooFastUp(float currentYVelocity) {
		return currentYVelocity > 16f;
	}
	
	// X velocity Tests
	bool ballGoingTooSlowLeft(float currentXVelocity) {
		return currentXVelocity <= 0f && currentXVelocity >= -1f;
	}
	
	bool ballGoingTooSlowRight(float currentXVelocity) {
		return currentXVelocity <= 1f && currentXVelocity >= 0f;
	}
	
	bool ballGoingTooFastLeft(float currentXVelocity) {
		return currentXVelocity < -16f;
	}
	
	bool ballGoingTooFastRight(float currentXVelocity) {
		return currentXVelocity > 16f;
	}
}

using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public Vector2 direction = Vector2.one;
	public float speed = 4f;
	public GameObject score;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		rigidbody2D.velocity = (direction * speed);
	}

	void OnTriggerEnter2D(Collider2D coll){

		switch (coll.tag) {
			case "TopWall":
				if (direction.y > 0 && direction.x > 0)
					clockwiseRotation ();
				else if (direction.y > 0 && direction.x < 0)
					anticlockwiseRotation ();
				break;
			case "BotWall":
				if (direction.y > 0 && direction.x > 0 || direction.y < 0 && direction.x > 0)
					anticlockwiseRotation ();
				else if (direction.y > 0 && direction.x < 0 || direction.y < 0 && direction.x < 0)
					clockwiseRotation ();
				break;
			case "RightWall":
				if(coll.name == "right")
					playerAScored();
				if (direction.y > 0 && direction.x > 0)
					anticlockwiseRotation ();
				else if (direction.y < 0 && direction.x > 0)
					clockwiseRotation ();
				break;
			case "LeftWall":
				if(coll.name == "left")
					playerBScored();
				if (direction.y > 0 && direction.x < 0)
					clockwiseRotation ();
				else if (direction.y < 0 && direction.x < 0)
					anticlockwiseRotation ();
				break;
		}

	}

	private void playerAScored(){
		score.SendMessage ("playerAScored");
		transform.position = new Vector3 (0, 0, 0);
	}

	private void playerBScored(){
		score.SendMessage ("playerBScored");
		transform.position = new Vector3 (0, 0, 0);
	}

	private void clockwiseRotation(){
		direction = new Vector2 (direction.y, -direction.x);
	}

	private void anticlockwiseRotation(){
		direction = new Vector2 (-direction.y, direction.x);
	}

}

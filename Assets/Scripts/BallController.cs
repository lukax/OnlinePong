using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public Vector2 direction = Vector2.one;
	public GameObject score;
    public float force = 400f;
    
    private Vector3 startPos;

	void Start () {
        startPos = GetComponent<Transform>().position;
        rigidbody2D.AddForce(direction * force);
	}
	
	void Update () {
	}

	void FixedUpdate(){

    }

	void OnTriggerEnter2D(Collider2D coll){
        switch (coll.tag)
        {
            case "RightWall":
                    playerAScored();
                break;
            case "LeftWall":
                    playerBScored();
                break;
        }

	}

	private void playerAScored(){
		score.SendMessage ("playerAScored");
        restartPos();
	}

	private void playerBScored(){
		score.SendMessage ("playerBScored");
        restartPos();
	}

    private void restartPos()
    {
        direction *= -1;
        transform.position = startPos;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(direction * force);
    }

}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public string axis = "";

    public Rigidbody2D PlayerA;
    public Rigidbody2D PlayerB;

	void Start () 
    {
	}
	
	void Update () 
    {
        var X = Input.acceleration.x;
        var Y = Input.acceleration.y;

        Rigidbody2D currPlayer = PlayerA;

        if (X < 0)
        {
            currPlayer = PlayerA;
            PlayerB.velocity = Vector2.zero;
        }
        else if (X > 0)
        {
            currPlayer = PlayerB;
            PlayerA.velocity = Vector2.zero;
        }

        if (Y > 0 && !isCollidingWith(currPlayer, "TopWall") ||
            Y < 0 && !isCollidingWith(currPlayer, "BotWall"))
            currPlayer.velocity = Vector2.up * 5 * Y;
        else
            currPlayer.velocity = Vector2.zero;
	}

    bool isCollidingWith(Rigidbody2D thisBody, string targetTag)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(thisBody.transform.position, 1f);
        foreach (Collider2D coll in hits)
        {
            if (hits != null && coll.CompareTag(targetTag))
            {
                Debug.Log("is colliding with: " + coll.tag);
                return true;
            }
        }
        return false;
    }
}

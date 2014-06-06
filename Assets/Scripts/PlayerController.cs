using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    [Range(1, 10)]
    public float Velocity = 5;

    public Rigidbody2D PlayerA;
    public Rigidbody2D PlayerB;

	void Start () 
    {
	}
	
	void Update () 
    {
        var A = Input.GetAxis("VerticalA");

        MovePlayer(PlayerA, A);
	}

    void MovePlayer(Rigidbody2D player, float axis)
    {
        if (axis > 0 && !isCollidingWith(player, "TopWall") ||
            axis < 0 && !isCollidingWith(player, "BotWall"))
            player.velocity = Vector2.up * Velocity * axis;
        else
            player.velocity = Vector2.zero;
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

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if (stream.isWriting)
        {
            float YPos = PlayerA.transform.position.y;
            stream.Serialize(ref YPos);
        }
        else
        {
            float YPos = 0;
            stream.Serialize(ref YPos);
            Debug.Log(YPos);
            PlayerB.transform.position = new Vector3(PlayerB.transform.position.x, YPos, PlayerB.transform.position.z);
        }
    }
}

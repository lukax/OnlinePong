using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public string axis = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		float axis = Input.GetAxis(this.axis);

		rigidbody2D.velocity = Vector2.up * 10 * axis;

	}
}

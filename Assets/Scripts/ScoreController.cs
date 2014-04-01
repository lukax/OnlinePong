using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
	public GUIText A;
	public GUIText B;
	
	private int scoreA = 0;
	private int scoreB = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		A.text = scoreA.ToString();
		B.text = scoreB.ToString();
	}

	void playerAScored(){
		scoreA ++;
	}

	void playerBScored(){
		scoreB ++;
	}

}

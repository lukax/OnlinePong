using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
	public GUIText A;
	public GUIText B;
	
	private int scoreA = 0;
	private int scoreB = 0;

	void Start () {
	}
	
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

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour {

	public static int score;
	TextMesh Text;
	
	
	void Awake () {
		Debug.Log (score);
		Text = GetComponent <TextMesh>();
        //This was hidden score for some reason
		score = ScoreManager.score;
		Debug.Log (score);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Total Score: " + score);
		Text.text = "Total Score: " + score;
	}
}


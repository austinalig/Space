using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour {

	public static int score;
	TextMesh Text;
	
	
	void Awake () {
		Text = GetComponent <TextMesh>();
		score = ScoreManager.hiddenscore;
	}
	
	// Update is called once per frame
	void Update () {
		Text.text = "Total Score: " + score;
		if (Input.GetKeyDown(KeyCode.Escape) == true)
		    Application.Quit();
	}
}


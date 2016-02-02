using UnityEngine;
using System.Collections;

public class timerDisplayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Mathf.Round(Time.time) % 5 == 0)
        {
            Debug.Log(Time.time);

        }
	
	}
}

using UnityEngine;
using System.Collections;

public class destroyTimer : MonoBehaviour {


    public float timeTilDeletion = float.MaxValue;
    System.Diagnostics.Stopwatch timer;

    // Use this for initialization
    void Start () {
        timer = new System.Diagnostics.Stopwatch();
        timer.Start();
	}
	
	// Update is called once per frame
	void Update () {
	    if(timer.ElapsedMilliseconds >= timeTilDeletion * 1000)
        {
            GameObject.Destroy(gameObject);
        }
	}
}

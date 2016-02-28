using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class notificationScript : MonoBehaviour {


    bool switching;
    bool displayed;
    public float time = 5;
    public float maxOpac = 1;
    public float minOpac = 0;
    float timeToWait;
    System.Diagnostics.Stopwatch timer;
    System.Diagnostics.Stopwatch switchTimer;
    // Use this for initialization
    void Start () {
        timeToWait = time * 1000;
        switching = false;
        displayed = false;
        timer = new System.Diagnostics.Stopwatch();
        switchTimer = new System.Diagnostics.Stopwatch();
        timer.Start();
        switchTimer.Start();
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(minOpac);

    }

    // Update is called once per frame
    void Update()
    {

        if (timer.ElapsedMilliseconds > timeToWait)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B pressed");
                try {
                    gameObject.GetComponent<AudioSource>().Play();
                }catch (Exception)
                {
                    //object might not have sound
                    //don't do anything if it doesn't
                }
                timer.Reset();
                timer.Start();
                switching = true;
                switchTimer.Reset();
                switchTimer.Start();
            }
        }

        if (switching)
        {
            if (displayed)
            {
                //decrease Opacity
                if (switchTimer.ElapsedMilliseconds / timeToWait < 1)
                {
                    gameObject.GetComponent<CanvasRenderer>().SetAlpha(maxOpac - (minOpac + (switchTimer.ElapsedMilliseconds / timeToWait)));
                }
                else
                {
                    gameObject.GetComponent<CanvasRenderer>().SetAlpha(minOpac);
                    displayed = false;
                    switching = false;
                    switchTimer.Stop();
                    switchTimer.Reset();

                }
            }
            else
            {
                //increase Opacity
                if (switchTimer.ElapsedMilliseconds / timeToWait < maxOpac)
                {
                    gameObject.GetComponent<CanvasRenderer>().SetAlpha(switchTimer.ElapsedMilliseconds / timeToWait);
                }
                else
                {
                    gameObject.GetComponent<CanvasRenderer>().SetAlpha(maxOpac);
                    displayed = true;
                    switching = false;
                    switchTimer.Stop();
                    switchTimer.Reset();
                }
            }

        }
    }

}

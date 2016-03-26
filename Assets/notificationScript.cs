using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class notificationScript : MonoBehaviour {


    public static int playerChoice;
    public GameObject thisNotification;
    public static bool playerIsChoosing;
    public static bool switching;
    public static bool playerChose;
    private bool selfSwitching;
    public int name;
    static bool[] finishedDisplaying;
    bool displayed;
    public float time = 5;
    public float maxOpac = 1;
    public float minOpac = 0;
    private static bool evolutionDetected = false;
    float timeToWait;
    System.Diagnostics.Stopwatch timer;
    System.Diagnostics.Stopwatch switchTimer;
    // Use this for initialization
    void Start () {

        finishedDisplaying = new bool[3];

        for(int i = 0; i < finishedDisplaying.Length; i++)
        {
            finishedDisplaying[i] = false;
        }

        timeToWait = time * 1000;
        switching = false;
        playerChose = true; //this is true for a reason
        selfSwitching = false;
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

        if (playerChose)
        {
            gameObject.GetComponent<CanvasRenderer>().SetAlpha(minOpac);
        }

        if (playerIsChoosing)
        {
            playerChose = false;
            gameObject.GetComponent<CanvasRenderer>().SetAlpha(maxOpac);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerChoice = 1;
                playerIsChoosing = false;
                Debug.Log("1Done updating");
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(minOpac);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerChoice = 2;
                playerIsChoosing = false;
                Debug.Log("2Done updating");
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(minOpac);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                playerChoice = 3;
                playerIsChoosing = false;
                Debug.Log("3Done updating");
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(minOpac);

            }

        }


        /*
        if (timer.ElapsedMilliseconds > timeToWait)
        {
            if (evolutionDetected)
            {
                try {
                    thisNotification.GetComponent<AudioSource>().Play();
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
            selfSwitching = true;
        }

        if (selfSwitching)
        {
            if (displayed)
            {
                //decrease Opacity
                if (switchTimer.ElapsedMilliseconds / timeToWait < 1)
                {
                    // GameObject.Find("rEVOLVErBlueLight").GetComponent<Light>().intensity = 1 - (0 + (switchTimer.ElapsedMilliseconds / timeToWait));
                    thisNotification.GetComponent<CanvasRenderer>().SetAlpha(maxOpac - (minOpac + (switchTimer.ElapsedMilliseconds / timeToWait)));
                }
                else
                {
                    //   GameObject.Find("rEVOLVErBlueLight").GetComponent<Light>().intensity = 0;
                    thisNotification.GetComponent<CanvasRenderer>().SetAlpha(minOpac);
                    displayed = false;
                    selfSwitching = false;
                    switchTimer.Stop();
                    switchTimer.Reset();
                    finishedDisplaying[name] = true;

                }
            }
            else
            {
                //increase Opacity
                if (switchTimer.ElapsedMilliseconds / timeToWait < maxOpac)
                {
                    // GameObject.Find("rEVOLVErBlueLight").GetComponent<Light>().intensity = (switchTimer.ElapsedMilliseconds / timeToWait);
                    thisNotification.GetComponent<CanvasRenderer>().SetAlpha(switchTimer.ElapsedMilliseconds / timeToWait);
                }
                else
                {
                    //   GameObject.Find("rEVOLVErBlueLight").GetComponent<Light>().intensity = 1;
                    thisNotification.GetComponent<CanvasRenderer>().SetAlpha(maxOpac);
                    displayed = true;
                    selfSwitching = false;
                    switchTimer.Stop();
                    switchTimer.Reset();
                    finishedDisplaying[name] = true;
                }
            }

        }

        if(finishedDisplaying[0] && finishedDisplaying[1] && finishedDisplaying[2])
        {
            switching = false;
            finishedDisplaying[0] = false;
            finishedDisplaying[1] = false;
            finishedDisplaying[2] = false;
        }*/
    }

    public void setGunSpecs(int choice)
    {
        
    }

    

}

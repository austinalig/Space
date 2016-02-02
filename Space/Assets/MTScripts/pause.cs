using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class pause : MonoBehaviour
{

    //make sure this is a sprite
    public GameObject pauseScreen;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseScreen.GetComponent<Image>().enabled = true;
            }
            else
            {
                pauseScreen.GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
            }
        }
    }
}

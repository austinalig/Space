using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{

    private GameObject pauseText;

    // Use this for initialization
    void Start()
    {
        pauseText = GameObject.Find("PauseText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseText.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                pauseText.GetComponent<SpriteRenderer>().enabled = false;
                Time.timeScale = 1;
            }
        }
    }
}

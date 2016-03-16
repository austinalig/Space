using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class perspectiveSwitcher : MonoBehaviour {

    private GameObject firstPerspective;
    private GameObject thirdPerspective;
    private GameObject firstCamera;
    private Behaviour player;
    private bool switcher;

	void Start () {
       //firstPerspective = GameObject.Find("FirstPersonCharacterController");
        firstCamera = GameObject.Find("firstCamera");
        thirdPerspective = GameObject.Find("ThirdPersonCharacter");
        switcher = true;
        player = GameObject.Find("FirstPersonCharacterController").GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {

            Debug.Log("Whatever");

            if (switcher)
            {
                //switch to third person

                player.enabled = false;
                
                firstCamera.SetActive(false);
                thirdPerspective.SetActive(true);
                switcher = false;
            }
            else
            {
                //switch to first
                this.gameObject.GetComponent<FirstPersonController>().enabled = true;
                firstCamera.SetActive(true);
                thirdPerspective.SetActive(false);
                switcher = true;
            }

        }

	}
}

using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour {
	private Transform cam;
	private bool flag;
	private bool cflag;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Transform> ();
		flag = true;
		cflag = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown (KeyCode.P))
		{//On "P" toggle the camera view by shifting the transform
			if (flag)
			{
				cam.position = (cam.position + (cam.rotation * new Vector3(0, 0, 3)));
				flag = false;
			}
			else 
			{
				cam.position = (cam.position + (cam.rotation * new Vector3(0, 0 ,-3)));
				flag = true;
			}
	} 
		if(Input.GetKeyDown (KeyCode.C))
		{//On "P" toggle the camera view by shifting the transform
			if (cflag)
			{
				cam.position = (cam.position + new Vector3(0 , -1, 0));
				cflag = false;
			}
			else 
			{
				cam.position = (cam.position + new Vector3(0 , 1, 0));
				cflag = true;
			}
	}
}
}
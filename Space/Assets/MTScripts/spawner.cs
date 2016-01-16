using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    public GameObject objectToSpawn;
    public int numberOfSpawns = 0;
    public Transform targetLocation;
    private GameObject [] clonesOfObject;
    private int spawnCount;
    //private float xPos;
   // private float zPos;
	// Use this for initialization
	void Start () {
        clonesOfObject = new GameObject[numberOfSpawns];
       // clonesOfObject[0] = GameObject.Instantiate(objectToSpawn);
      //  xPos = targetLocation.position.x;
      //  zPos = targetLocation.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(spawnCount < numberOfSpawns)
        {
            GameObject.Instantiate(objectToSpawn);
           // clonesOfObject[spawnCount].trasnform = new Vector3()
            spawnCount++;
        }

	}
}

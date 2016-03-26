using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class successTester : MonoBehaviour {

    private System.Diagnostics.Stopwatch successTimer;

    //shoot variables
    public GameObject locationOfPlayerShoot;
    public Text notificationText1;
    public Text notificationText2;
    public Text notificationText3;


    public float timeToCheckSuccesses;//in miliseconds
    private int speedLocation = 0;
    private int fireRateLocation = 1;

    //added variables from Montrel
    private int xScaleLocation = 2;
    private int yScaleLocation = 3;
    private int zScaleLocation = 4;
    private int destroyAfterLocation = 5;
    bool updated = false;

    // Use this for initialization
    void Start () {
        successTimer = new System.Diagnostics.Stopwatch();
        centralHub.init();
        successTimer.Start();

    }
	
	// Update is called once per frame
	void Update () {


        
        if (successTimer.ElapsedMilliseconds >= timeToCheckSuccesses && !notificationScript.playerIsChoosing && notificationScript.playerChose)
        {
            successTimer.Stop();
            successTimer.Reset();
            centralHub.updatingChoices = true;
            centralHub.calculate();
            while (centralHub.updatingChoices)
            {
                //wait for the central hub to finish updating
            }

            notificationText1.text = "rEVOLVEr Evolution Detected:\nPossible Update:\nSpeed: " + centralHub.clone1[speedLocation] + "\nFire Rate: " + centralHub.clone1[speedLocation] + "\nSizeChange: (" + centralHub.clone1[xScaleLocation] + ", " + centralHub.clone1[yScaleLocation] + ", " + centralHub.clone1[zScaleLocation] + ")"
                + "timeLasting: " + centralHub.clone1[destroyAfterLocation];
            notificationText2.text = "\nPossible Update:\nSpeed: " + centralHub.clone2[speedLocation] + "\nFire Rate: " + centralHub.clone2[speedLocation] + "\nSizeChange: (" + centralHub.clone2[xScaleLocation] + ", " + centralHub.clone2[yScaleLocation] + ", " + centralHub.clone2[zScaleLocation] + ")"
                + "timeLasting: " + centralHub.clone2[destroyAfterLocation];
            notificationText3.text = "Keep your current model";

            notificationScript.playerIsChoosing = true;

            notificationScript.switching = true;

        }

        if (notificationScript.playerChoice != 3)
        {
            Debug.Log(1);
        }

        if (!notificationScript.playerIsChoosing)
        {
            Debug.Log(2);
        }

        if (!notificationScript.playerChose)
        {
            Debug.Log(3);
        }

        if (!notificationScript.playerIsChoosing && !notificationScript.playerChose)
        {
            if (notificationScript.playerChoice != 3)
            {
                updateWeapon();
            }
            successTimer.Start();
            Debug.Log("updates should disappear");
            notificationScript.playerChose = true;
        }


    }


        public void updateWeapon(){

        locationOfPlayerShoot.GetComponent<Shoot>().speed += locationOfPlayerShoot.GetComponent<Shoot>().speed * centralHub.attributeIncrease[speedLocation];
        locationOfPlayerShoot.GetComponent<Shoot>().fireRate += locationOfPlayerShoot.GetComponent<Shoot>().fireRate * centralHub.attributeIncrease[fireRateLocation];
        locationOfPlayerShoot.GetComponent<Shoot>().xScale += locationOfPlayerShoot.GetComponent<Shoot>().xScale * centralHub.attributeIncrease[xScaleLocation];
        locationOfPlayerShoot.GetComponent<Shoot>().yScale += locationOfPlayerShoot.GetComponent<Shoot>().yScale * centralHub.attributeIncrease[yScaleLocation];
        locationOfPlayerShoot.GetComponent<Shoot>().zScale += locationOfPlayerShoot.GetComponent<Shoot>().zScale * centralHub.attributeIncrease[zScaleLocation];
        locationOfPlayerShoot.GetComponent<Shoot>().destroyAfter += locationOfPlayerShoot.GetComponent<Shoot>().destroyAfter * centralHub.attributeIncrease[destroyAfterLocation];
        

    }



    
}

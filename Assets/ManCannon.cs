using UnityEngine;
using System.Collections;

public class ManCannon : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  transform.Translate(transform.forward*1*Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter called");
        if (other.tag == "Untagged")
            Debug.Log("floor");
        else
        {
            Debug.Log("Stay occurring");
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000, ForceMode.Acceleration);
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000, ForceMode.Acceleration);
        }

    }
    /*
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Untagged")
            Debug.Log("floor");
        else
        {
            Debug.Log("Stay occurring");
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000, ForceMode.Acceleration);
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000, ForceMode.Acceleration);
        }
    }
    */
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit called");
    }
}

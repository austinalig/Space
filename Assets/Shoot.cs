using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public float speed = 10;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;

    //added variables from Montrel
    public string buttonName = "Fire1";
    public float xScale = 1;
    public float yScale = 1;
    public float zScale = 1;
    public float destroyAfter = 10;

    void Update() {
		if (Input.GetButton(buttonName) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Rigidbody clone = Instantiate(projectile, transform.position, transform.rotation)as Rigidbody;
			if(clone != null){
			clone.velocity = transform.TransformDirection(Vector3.forward * speed);}
            clone.transform.localScale += new Vector3(xScale, yScale, zScale);
            clone.gameObject.AddComponent<destroyTimer>();
            clone.gameObject.GetComponent<destroyTimer>().timeTilDeletion = destroyAfter;

        }
	}
}
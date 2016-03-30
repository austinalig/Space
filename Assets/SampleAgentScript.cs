using UnityEngine;
using System.Collections;

public class SampleAgentScript : MonoBehaviour {
	public int seekrad;
	public GameObject target;
	NavMeshAgent agent;
	public int health = 5;
	private int currenthealth;
	public GameObject bullet;
	public int scoreValue = 10;
	public int levelValue = 2500;
    public bool fire = false;
    private int state = 1;
    private float random;
    private int level;
    public int walkRadius;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        currenthealth = health + LevelManager.level;
        agent = GetComponent<NavMeshAgent>();
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (level < LevelManager.level)
        {
            agent.speed += 5;
            agent.angularSpeed += 5;
            agent.acceleration++;
            level++;
        }
        random = Time.time;
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
            //FSM, 1 = seek, 0 = target aquired, 2 is roam
            if (hit.collider.tag == target.tag)
                state = 0;
        if (state == 1)
        {
            if ((agent.transform.position - target.transform.position).magnitude > seekrad)
                agent.SetDestination(target.transform.position);
            else
            {
                agent.SetDestination(agent.transform.position);
                state = 2;
            }
        }
        else if (state == 2)
        {
            if ((agent.transform.position - target.transform.position).magnitude < (seekrad + 25))
            {
                randomDirection = (random * Vector3.up) + (random * Vector3.left);
                agent.SetDestination(randomDirection);
            }
            else
                state = 1;
        }
        else if (state == 0)
        {
            agent.SetDestination(target.transform.position);
            if (hit.collider.name == target.name)
                fire = true;
            else
                fire = false;
        }
    }
    void OnTriggerEnter(Collider other) {
		if (other.tag == bullet.tag) {
			currenthealth = currenthealth - 1;
			if (currenthealth <= 0){

				ScoreManager.score += scoreValue;
				Destroy (gameObject);
				if ((ScoreManager.score / LevelManager.level) > levelValue){
					LevelManager.level += 1;
				}

			}
		} else
			Debug.Log (other.tag);
	}
}

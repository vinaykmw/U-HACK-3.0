using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class waterDestination : MonoBehaviour {
    public int destinationNo;
    public GameObject[] destinations;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent= this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(destinations[destinationNo].GetComponent<Transform>().position);
	}

    public void SetDropDestination(GameObject destination)
    {
        agent.SetDestination(destination.GetComponent<Transform>().position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("dest"))
        {
        //    other.GetComponent<waterNeed>().addMoister();
            Destroy(this.gameObject, .01f);
  
        }
    }
}

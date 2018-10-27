using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class drop_target : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject destination;
    public GameObject destination2;

    // public Transform target_location;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        // destination= GameObject.FindGameObjectsWithTag("dest");
        //   int a = Random.Range(0, destination.Length);
        int z = Random.Range(0, 2);
        if (z == 1)
        {
            Transform p = GameObject.FindGameObjectWithTag("dest1").GetComponent<Transform>();
            agent.SetDestination(p.position);
        }
        else
        {
            Transform p = GameObject.FindGameObjectWithTag("dest2").GetComponent<Transform>();
            agent.SetDestination(p.position);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dest1")||other.CompareTag("dest2"))
        {
            other.GetComponent<moisterChange>().increaseMoister();
            Debug.Log(" trigger ");
            Destroy(this.gameObject,0.1f);
        }
    }
   /* public void Set_target_location(int  a)
    {
        Debug.Log("Target Position Set");
        agent.SetDestination(destination[a].transform.position);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            Destroy(other.gameObject, .1f);
        }
    }
}

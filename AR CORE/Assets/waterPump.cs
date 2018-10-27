using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterPump : MonoBehaviour {
    public GameObject water;
   
    
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
               // Debug.Log("Spawning waves");
               GameObject obj = Instantiate(water, this.transform.position, this.transform.rotation);
               
                yield return new WaitForSeconds(.5f);
                Destroy(obj, 30);

            }
            yield return new WaitForSeconds(0.1f);

            
        }
    }
}

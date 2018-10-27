using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class waterNeed : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int moisterContent = 50;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void addMoister()
    {
        moisterContent++;
    }

}
/*
public class waterNeed : MonoBehaviour {
    public GameObject tank;
    public int moisterMinusTime;
 //   public GameObject location;
    public GameObject waterDrop;
    public int moisterContent=50;
    // Use this for initialization
    void Start() {
        StartCoroutine(waterNeedStart());
        StartCoroutine(moisterDecrese());
    }

    IEnumerator waterNeedStart()
    { while (true)
            if (moisterContent < 45)
            {
                Instantiate(waterDrop, tank.transform.position, tank.transform.rotation);
                yield return new WaitForSeconds(.4f);
            }
    }

    IEnumerator moisterDecrese()
    {
        while (true)
        { yield return new WaitForSeconds(moisterMinusTime);
            
            { for (int i = 0; i < 3; i++)
                    moisterContent = moisterContent - 1;
            }
            yield return new WaitForSeconds(5f);
        }
    }


        // Update is called once per frame
       
    } 
    */

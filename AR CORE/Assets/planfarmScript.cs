using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planfarmScript : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

    public void LoadPlanningMode()
    {
        SceneManager.LoadScene(1);
    }
}

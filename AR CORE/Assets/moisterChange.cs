using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moisterChange : MonoBehaviour {
    public int totalMoister;
    public int maxMoister = 50;
    public Text moisterText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(totalMoister <maxMoister )
          moisterText.text = "moisture " + totalMoister.ToString() + " %";
	}
    public void increaseMoister()
    {
        totalMoister = totalMoister + 1;
    }
    public void makeMoistureZero()
    {
        totalMoister = 0;
    }


}

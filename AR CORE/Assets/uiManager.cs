using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour {
    public GameObject pannel;
    public GameObject liveView;
    public GameObject Notification;
    public GameObject Ground;
    public GameObject pipe;
    int g = 0;
    int p = 0;
    int n = 0;

    // Use this for initialization
    void Start () {
        pannel.SetActive(true);
        liveView.SetActive(false);
        pipe.SetActive(false);
        Ground.SetActive(true);
        Notification.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void pannelOf()
    {
        pannel.SetActive(false);
        liveView.SetActive(true);
    }
    public void pannelOn()
    {
        pannel.SetActive(true);
        liveView.SetActive(false);

    }
    public void groundhow()
    {   if (g == 0)
        {
            Ground.SetActive(true);
            g = 1;
        }
       else if (g == 1)
        {
            Ground.SetActive(false);
            g = 0;

        }
    }


    public void pipeShow()
    {
        if (p == 0)
        {
            pipe.SetActive(true);
            p = 1;
        }
       else if (p == 1)
        {
            pipe.SetActive(false);
            p = 0;

        }
    }

    public void showNotifications()
    {
        if (n == 0)
        {
            Notification.SetActive(true);
            n = 1;
        }
        else if (n == 1)
        {
            Notification.SetActive(false);
            n = 0;

        }
    }
}

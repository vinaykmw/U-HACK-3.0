using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public GameObject imageSun;
    int i = 0;
    // Use this for initialization
    void Start()
    {
        imageSun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void turnofImage()
    {
        if (i == 0)
        {
            imageSun.SetActive(true);
            i = 1;
        }
        else if (i == 1)
        {
            imageSun.SetActive(false);
            i = 0;
        }

    }
}

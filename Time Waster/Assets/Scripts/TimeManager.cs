using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{

    public DateTime time;
    public Vector3 currTime;

    // Start is called before the first frame update
    void Start()
    {
        time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
            time = DateTime.Now;
        currTime.x = time.Hour;
        currTime.y = time.Minute;
        currTime.z = time.Second;

    }
}

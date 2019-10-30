using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private Transform hourHand;
    [SerializeField] private Transform minuteHand;
    [SerializeField] private Transform secondHand;

    [SerializeField] private TimeManager timer;

    // Start is called before the first frame update
    void Start()
    {
        //hourHand.Rotate(timer.currTime.x * 0.00166666666666666666666666666667f);
        //minuteHand.Rotate(Vector3.forward, timer.currTime.y * 0.00166666666666666666666666666667f);
        secondHand.Rotate(Vector3.forward, timer.currTime.z * 6);
    }

    // Update is called once per frame
    void Update()
    {

        hourHand.Rotate(Vector3.forward, -Time.deltaTime * 0.00166666666666666666666666666667f);
        minuteHand.Rotate(Vector3.forward, -Time.deltaTime * 0.1f);
        secondHand.Rotate(Vector3.forward, -Time.deltaTime * 6);
    }
}

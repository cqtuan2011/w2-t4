using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Clock : MonoBehaviour
{
    public GameObject secondsHand;
    public GameObject minutesHand;
    public GameObject hoursHand;

    public bool smoothRotation = false;

    void Update()
    {
        DateTime currentTime = DateTime.Now;

        float hoursDegree = -(currentTime.Hour / 12f) * 360f;

        hoursHand.transform.localRotation = Quaternion.Euler(0, 0, hoursDegree);

        float secondsDegree = -(currentTime.Second / 60f) * 360f;
        Vector3 secondsDirection = new Vector3(0, 0, secondsDegree);
        float minutesDegree = -(currentTime.Minute / 60f) * 360f;
        Vector3 minutesDirection = new Vector3(0, 0, minutesDegree);

        switch (smoothRotation)
        {
            case true:
            secondsHand.transform.DORotate(secondsDirection, 10, RotateMode.Fast);
            minutesHand.transform.DORotate(minutesDirection, 10, RotateMode.Fast);
                break;
            case false:
                secondsHand.transform.DORotate(secondsDirection, Time.deltaTime, RotateMode.Fast);
                minutesHand.transform.DORotate(minutesDirection, Time.deltaTime, RotateMode.Fast);
                break;
        } 
    }
}

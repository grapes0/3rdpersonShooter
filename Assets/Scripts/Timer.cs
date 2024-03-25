using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text targetText;
    public UnityEvent onTimerEnd;

    private TimeSpan zeroTime = TimeSpan.Zero;
    void Update()
    {

        timer -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timer);
        targetText.text = time.ToString("mm\\:ss");
    }

    void EventDelay()
    {
        onTimerEnd.Invoke();
    }
    void Start()
    {
        Invoke("EventDelay", timer);
    }
}

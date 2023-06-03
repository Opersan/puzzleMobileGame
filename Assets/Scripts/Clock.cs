using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    int hour_ = 0;
    int minute_ = 0;
    int second_ = 0;

    private Text textClock;
    private float delta_time;
    private bool stop_clock = false;

    public static Clock ins;

    void Start()
    {
        stop_clock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSettings.ins.getPaused() == false && stop_clock == false)
        {
            delta_time += Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(delta_time);

            string hour = LeadingZero(span.Hours);
            string minute = LeadingZero(span.Minutes);
            string second = LeadingZero(span.Seconds);

            textClock.text = hour +  ":" + minute + ":" + second;
        }
    }

    private void Awake()
    {
        if (ins)
        {
            Destroy(ins);
        }
        ins = this;
        textClock = GetComponent<Text>();
        if(GameSettings.ins.GetContinuePreviousGame())
        {
            delta_time = Config.ReadGameTime();
        } else
        {
            delta_time = 0;
        }
    }

    string LeadingZero(int a)
    {
        return a.ToString().PadLeft(2, '0');
    }

    public void OnGameOver()
    {
        stop_clock = true;
    }

    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
    }

    public static string GetCurrentTime()
    {
        return ins.delta_time.ToString();
    }

    public Text GetCurrentTimeText()
    {
        return textClock;
    }
}

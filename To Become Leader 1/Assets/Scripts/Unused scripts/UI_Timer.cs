using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    //if you selected the whole format timeFormats, render the value to zero (string)
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime += Time.deltaTime;
        if(hasLimit && (currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
    }

    void SetTimerText()
    {
        timerText.text = hasFormat ? "Time: " + currentTime.ToString(timeFormats[format]) : "Time: " + currentTime.ToString();
        
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}

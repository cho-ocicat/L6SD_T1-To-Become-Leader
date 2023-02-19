using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Timer2 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float startTime;
    
    bool finished = true;

    // Start is called before the first frame update
    void Start()
    {
        //startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finished){
            return;
        }

        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        //f(number) is how much decimals you want to show
        string seconds = (t % 60).ToString("f2");

        timerText.text = "Time: " + minutes + ":" + seconds;

        // if(minutes =< 2)
        // {
        //     Debug.Log("You win!");
        // }
        // else if(2 < minutes =< 5)
        // {
        //     Debug.Log("Better luck next time!");
        // }
        // else
        // {
        //     Debug.Log("Seriously?");
        // }

        if(minutes.Equals("60"))
        {
            timerText.color = Color.red;
            finished = true;
        }
        //Result();
    }

    public void StartTimer() //dont foregt to add collider to first platform and call this function
    {
        finished = false;
        startTime = Time.time;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.green;
    }

    // public void Result()
    // {
    //     if(finished)
    //     {
    //         timerText.text
    //     }
        
    //     if(finished)
    //     {
    //         if(minutes.Equals("0") || minutes.Equals("1"))
    //         {
    //             Debug.Log("You win!");
    //         }
    //         else if (minutes.Equals("2") || minutes.Equals("3") || minutes.Equals("4"))
    //         {
    //             Debug.Log("You win!");
    //         }
    //         else
    //         {
    //             Debug.Log("Better luck next time!");
    //         }
    //     }
        
    // }
}

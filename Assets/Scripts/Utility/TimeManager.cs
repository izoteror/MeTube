using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    private int _day;
    private DateTime _date;

    public int Day { get => _day; set => _day = value; }
    public DateTime Date { get => _date; set => _date = value; }

    void Start()
    {
        Date = new DateTime(2020, 01, 01);
        
        if (DayCounterEvent != null)
            DayCounterEvent();
        StartCoroutine(DayCounter());
    }
    public static event UnityAction DayCounterEvent;

  public static void ToPause(bool pause)
    {
        if (pause == true)
            Time.timeScale = 0;
        else if (pause == false)
            Time.timeScale = 1;
    }

    public void Pause(bool pause)
    {
        if (pause == true)
            Time.timeScale = 0;
        else if (pause == false)
            Time.timeScale = 1;
    }
    // Update is called once per frame
    IEnumerator DayCounter()
    {
        while(true)
        {
            Day++;
           Date= Date.AddDays(1);
            
            yield return new WaitForSeconds(10f);
            if (DayCounterEvent != null)
                DayCounterEvent();
        }
        
    }
}

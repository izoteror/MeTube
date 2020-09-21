using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static float _moneyperday;

    

    // Start is called before the first frame update
    void Start()
    {
        
        TimeManager.DayCounterEvent += MoneyModel;
    }

    private void MoneyModel()
    {
        PlayerPrefs._playerPref.money += _moneyperday;
        
    }

    public static void MoneyPerDay(ThemeItem theme, int viewsperday,Video video)
    {
       
        _moneyperday = (viewsperday * theme.MoneyEffective)/1000;
    }

   
}

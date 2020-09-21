using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPresenter : MonoBehaviour
{
    [SerializeField] private GameObject daysText;
    [SerializeField] private GameObject moneyText;
    [SerializeField] private GameObject followersText;
    private Text daysTextField;
    private Text moneyTextField;
     private Text followersTextField;
    

    void Start()
    {
        daysTextField = daysText.GetComponent<Text>();
        moneyTextField = moneyText.GetComponent<Text>();
        followersTextField = followersText.GetComponent<Text>();
        moneyTextField.text = "На счету в банке: " + PlayerPrefs._playerPref.money;
     
     
        daysTextField.text = Camera.main.GetComponent<TimeManager>().Date.ToString("yyyy/MM/dd \n dddd");
        followersTextField.text = "MeTube поддписчики: " + PlayerPrefs._playerPref.followers;
        TimeManager.DayCounterEvent += Presenter;
    }

    private void Presenter()
    {
        daysTextField.text = Camera.main.GetComponent<TimeManager>().Date.ToString("yyyy/MM/dd \n dddd");
        moneyTextField.text = "На счету в банке: " + PlayerPrefs._playerPref.money;
        followersTextField.text = "MeTube поддписчики: " + PlayerPrefs._playerPref.followers;
    }

   
}

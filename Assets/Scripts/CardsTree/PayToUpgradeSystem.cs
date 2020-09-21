using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PayToUpgradeSystem : MonoBehaviour
{

    [SerializeField] private Text _nameText;
    [SerializeField] private Slider _slider;
    private UpgradeCardItem localcurrentupgrade;
    private int pointperclick = 1;
    private int pointperday = 1;
    private int points;
    private int pointsTogoal;

    private void Start()
    {
        TimeManager.DayCounterEvent += DayUpgrade;
     
    }

    private void DayUpgrade()
    {
        DayPoints();
    }

    private void DayPoints()
    {
        points += pointperday;
        localcurrentupgrade.currentLearnScore = points;
        _slider.value = points;
        if (points == pointsTogoal) Done();
    }

    private void Done()
    {
        
        transform.parent.gameObject.SetActive(false);
        localcurrentupgrade.Upgrade();
    }

    public void ClickPoint()
    {
        points += pointperclick;
        localcurrentupgrade.currentLearnScore = points;
        _slider.value = points;
        if (points == pointsTogoal) Done();
    }

   public void PayToUpgrade(UpgradeCardItem currentupgrade)
    {
        localcurrentupgrade = currentupgrade;
        pointsTogoal = currentupgrade.scoreToLearn;
        points = currentupgrade.currentLearnScore;
        
        _nameText.text = currentupgrade.GetComponent<UpgradeCardItem>().Nameofupgrade;
        _slider.maxValue = pointsTogoal;
        _slider.value = points;
        



    }
}

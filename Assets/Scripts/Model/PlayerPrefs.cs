using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs :MonoBehaviour

{
   public List<Element> _playerCards;
   public List<Video> videoList = new List<Video>();
   public ThemeItem currenttheme;
   private string chanelName;
   public int followers; 
   public float lvl; 

   public float money;
   

    public static PlayerPrefs _playerPref;

    public string ChanelName { get => chanelName; set => chanelName = value; }

    private void Awake()
    {
        if (_playerPref != null)
            Destroy(this);
        if (_playerPref == null)
            _playerPref= this;
        //ReloadPrefs();
        UnityEngine.PlayerPrefs.DeleteAll();
        TimeManager.DayCounterEvent += RefreshPlayerPrefs;
    }

    public void ReloadPrefs()
    {
        foreach (Element card in _playerCards)
        {
           card.Effect = UnityEngine.PlayerPrefs.GetFloat(card.Name + "Effect");
           card.PercentEffect = UnityEngine.PlayerPrefs.GetFloat(card.Name + "Percent");
        }
        lvl=  UnityEngine.PlayerPrefs.GetFloat("lvl");
        money = UnityEngine.PlayerPrefs.GetFloat("money");
        followers= UnityEngine.PlayerPrefs.GetInt("followers");
        Camera.main.GetComponent<TimeManager>().Day=UnityEngine.PlayerPrefs.GetInt("Day");

       
       
    }

    private void RefreshPlayerPrefs()
    {
        foreach(Element card in _playerCards)
        {
            if (card.Type==2 & card.Effect*card.PercentEffect > lvl) lvl = card.Effect*card.PercentEffect;            
        }


    }
    private void OnApplicationQuit()
    {
        foreach (Element card in _playerCards)
        {
            UnityEngine.PlayerPrefs.SetFloat(card.Name + "Effect", card.Effect);
            UnityEngine.PlayerPrefs.SetFloat(card.Name + "Percent", card.PercentEffect);
        }
        UnityEngine.PlayerPrefs.SetFloat("lvl", lvl);
        UnityEngine.PlayerPrefs.SetFloat("money", money);
        UnityEngine.PlayerPrefs.SetInt("followers", followers);
        UnityEngine.PlayerPrefs.SetInt("Day", Camera.main.GetComponent<TimeManager>().Day);

        foreach (UpgradeCardItem upgradecards in CardsTree.cardtreeST.UpgradeListCard)
        {
            UnityEngine.PlayerPrefs.SetString(upgradecards.name, upgradecards.name);
            UnityEngine.PlayerPrefs.SetInt(upgradecards.name + "score", upgradecards.currentLearnScore);
            SetBoolPlayerPrefs(upgradecards.name + "done", upgradecards.done);
        }
        if (VideoManager.videomanagerST)
        {
            foreach (Video video in VideoManager.videomanagerST.videoList)
            {
                UnityEngine.PlayerPrefs.SetString(video.Name, video.Name);
                UnityEngine.PlayerPrefs.SetInt(video.Name + "Views", video.ViewsVideo);
                UnityEngine.PlayerPrefs.SetFloat(video.Name + "Difficult", video.Difficult);
            }
            UnityEngine.PlayerPrefs.SetInt("VideoList", VideoManager.videomanagerST.videoList.Count);
        }
        if (ThemeGenerator.ThemeGeneratorST)
        {
            foreach (ThemeItem theme in ThemeGenerator.ThemeGeneratorST.ThemeList)
            {
                UnityEngine.PlayerPrefs.SetString(theme.Name, theme.Name);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "Interest", theme.Interest);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "Difficult", theme.Difficult);
                UnityEngine.PlayerPrefs.SetInt(theme.Name + "Dayviews", theme.DayViews);
                UnityEngine.PlayerPrefs.SetInt(theme.Name + "Daylife", theme.Daylife);
                UnityEngine.PlayerPrefs.SetInt(theme.Name + "Lvl", theme.Lvl);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "Maxdifficult", theme.Maxdifficult);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "MoneyEffective", theme.MoneyEffective);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "Competition", theme.Competition);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "Competitionratio", theme.Competitionratio);
                UnityEngine.PlayerPrefs.SetFloat(theme.Name + "Views", theme.Views);
            }
            UnityEngine.PlayerPrefs.SetInt("ThemeList", ThemeGenerator.ThemeGeneratorST.ThemeList.Count);
        }
    }

    public static void SetBoolPlayerPrefs(string key, bool state)
    {
        UnityEngine.PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    

    public static bool GetBoolPlayerPrefs(string key)
    {
        int value = UnityEngine.PlayerPrefs.GetInt(key);

        if (value == 1)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}

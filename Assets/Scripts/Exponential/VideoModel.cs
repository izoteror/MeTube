using CenterSpace.Free;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class VideoModel : MonoBehaviour
{

    private Video _currentvideo;
    private int positioninqueu;
    private float _currentdamage;
    private ThemeItem _currenttheme;
    private GameObject videoPanel;
    private GameObject videoObj;
    private int viewsperday;
    // Start is called before the first frame update

   
    void Start()
    {
        videoObj = this.transform.gameObject;


    }

    public void Model(Video item,ThemeItem currenttheme,float damage)
    {
        _currentdamage = damage;
        _currentvideo = item;
        _currenttheme = currenttheme;
        


    }

    public void RefreshVideo()
    {
        if (_currenttheme.Interest < 0)
        {
            VideoManager.videomanagerST.DeleteVideo(this, _currentvideo);
            return;
        }
        _currentvideo.Views = _currenttheme.Views;
        _currentvideo.Difficult = _currentdamage / _currenttheme.Difficult;
         
        Debug.Log("_currenttheme: "+_currenttheme.Name +" Damage: " + _currentdamage + " _currenttheme.Interest " + _currenttheme.Interest);
         _currentvideo.MinChanels = 0;
        _currentvideo.MaxChanels = _currenttheme.Competition+1;
        int auditory = (_currenttheme.Views);
        int coefficient = 1;
        if (_currentvideo.MaxChanels > 100)
        {
            auditory = _currenttheme.Views / _currentvideo.MaxChanels * 100;
            
            _currentvideo.MaxChanels = 100;
        }
        if(auditory<=0)
        {
            VideoManager.videomanagerST.DeleteVideo(this, _currentvideo);
            return;
        }
        coefficient = _currenttheme.Views / auditory;
        positioninqueu = Mathf.RoundToInt(Mathf.Log(_currentvideo.Difficult + 1) * _currentvideo.MaxChanels);
        if (positioninqueu > _currentvideo.MaxChanels)
            positioninqueu = _currentvideo.MaxChanels;
        
     
        viewsperday =coefficient* DistributionVideoViews.DistributionST.CreateGraph(auditory, _currentvideo.MinChanels, _currentvideo.MaxChanels, positioninqueu,videoObj);
        _currentvideo.ViewsVideo += viewsperday;
        PlayerPrefs._playerPref.followers += AddFollowers(viewsperday, Mathf.Log(_currentvideo.Difficult + 1));
        MoneyManager.MoneyPerDay(_currenttheme,viewsperday,_currentvideo);
        _currentvideo.Positioninque = positioninqueu;
        Debug.Log("position: " + positioninqueu + " competition: " + _currentvideo.MaxChanels + " dificult: " + _currenttheme.Interest +" viewsperday: "+ viewsperday +" аудитория " +auditory);
    }

    public int AddFollowers(int viewsperday, float result)
    {
        NormalDist normalDist = new NormalDist(1, 0.3f);
        float cdfgood = Convert.ToSingle(normalDist.CDF(result));
        Debug.Log(cdfgood + " cdf + result+ "+ result);
        int currentfollowers =0;
        currentfollowers = Mathf.RoundToInt(cdfgood * viewsperday);

        _currentvideo.Followers = currentfollowers;
        return currentfollowers;
    }
   

}

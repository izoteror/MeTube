using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class VideoPresenter : MonoBehaviour, IPointerClickHandler
{
    public Image Icon;
    public Text text;
    public Text Views;
    public Text Followers;
    private Video _currentvideo;


    private void Awake()
    {
        TimeManager.DayCounterEvent += RefreshVideo;
    }

    private void RefreshVideo()
    {
        
        Views.text = "Просмотры: " + _currentvideo.ViewsVideo.ToString()+ " Позиция видео: " + (_currentvideo.MaxChanels- _currentvideo.Positioninque) + " из " + _currentvideo.MaxChanels;
        Icon.sprite = _currentvideo.Icon;
        text.text = "Имя ролика " + _currentvideo.Name;
        Followers.text = "Добавилось подписчиков: "+ _currentvideo.Followers;
    }

    public void Present(Video item)
    {

        _currentvideo = item;
        RefreshVideo();

    }
    public void OnPointerClick(PointerEventData eventData)
    {

        

    }

}

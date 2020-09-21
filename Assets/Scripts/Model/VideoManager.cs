using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private GameObject VideoPrefab;
    private ThemeItem currenttheme;
    public static VideoManager videomanagerST;
    public List<Video> videoList = new List<Video>();
    private List<GameObject> videoObjList = new List<GameObject>();

    private GameObject player;
    private void Awake()
    {
        if (videomanagerST != null)
            Destroy(this);
        if (videomanagerST == null)
            videomanagerST = this;

        player = GameObject.FindGameObjectWithTag("Player");
        videoList = PlayerPrefs._playerPref.videoList;
        

        TimeManager.DayCounterEvent += RefreshVideo;
    }

    private void RefreshVideo() //обратный цикл реалищован для избежания ошибки Collection modified из-за Delete();
    {
        for (int x = videoObjList.Count - 1; x >= 0; x--)
        {
            videoObjList[x].GetComponent<VideoModel>().RefreshVideo();
        }
    }

    public void CreateVideo(float damage)
    {
        currenttheme = PlayerPrefs._playerPref.currenttheme;
        Video currentvideo = new Video();
      
        currentvideo.Views =currenttheme.Views;
        currentvideo.Name = CreateVideoMain.GetDataFromThemeST.CurrentVideoName;
        currentvideo.Icon = CreateVideoMain.GetDataFromThemeST.CurrentVideoImage;
        GameObject videoObj = Instantiate(VideoPrefab, transform);
        videoList.Add(currentvideo);
        
        videoObj.GetComponent<VideoModel>().Model(currentvideo,currenttheme,damage);
        videoObj.GetComponent<VideoPresenter>().Present(currentvideo);
        videoObjList.Add(videoObj);
        currenttheme = null;
        TimeManager.ToPause(false);
    }

    public void DeleteVideo(VideoModel videomodel, Video video)
    {
        videoObjList.Remove(videomodel.gameObject);
        Destroy(videomodel.gameObject);
        PlayerPrefs._playerPref.videoList.Remove(video);
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Video : MonoBehaviour
{
    [SerializeField] private List<Sprite> ThemeIcons;
    [SerializeField] private List<string> ThemeNames;

    [SerializeField] private string nameVideo;
    [SerializeField] private float competition;
    [SerializeField] private int views;
    [SerializeField] private int viewsVideo;
    [SerializeField] private List<int> dayviews;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject view;
    [SerializeField] private float interest;
    [SerializeField] private float _difficult;
    [SerializeField] private float _positioninque;
    [SerializeField] private float _followers;

    [SerializeField] private int minChanels;
    [SerializeField] private int maxChanels;
    [SerializeField] private int playerbucket;
   


    

    public string Name { get => nameVideo; set => nameVideo = value; }
    public float Interest { get => interest; set => interest = value; }
    public float Competition { get => competition; set => competition = value; }
    public int Views { get => views; set => views = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public GameObject View { get => view; set => view = value; }

    public int MinChanels { get => minChanels; set => minChanels = value; }
    public int MaxChanels { get => maxChanels; set => maxChanels = value; }
    public int PlayerBucket { get => playerbucket; set => playerbucket= value; }
   
    public List<int> Dayviews { get => dayviews; set => dayviews = value; }
    public int ViewsVideo { get => viewsVideo; set => viewsVideo = value; }
    public float Difficult { get => _difficult; set => _difficult = value; }
    public float Positioninque { get => _positioninque; set => _positioninque = value; }
    public float Followers { get => _followers; set => _followers = value; }
}

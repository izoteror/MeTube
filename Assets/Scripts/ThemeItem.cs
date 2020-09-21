
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ThemeItem : MonoBehaviour
{
    [SerializeField] private List<Sprite> ThemeIcons;
    [SerializeField] private List<string> ThemeNames;

    [SerializeField] private string nameTheme;
      [SerializeField] private int competition;
    [SerializeField] private float competitionratio;
    [SerializeField] private int views;
      [SerializeField] private List<int> dayviewslist;
      [SerializeField] private Sprite icon;
      [SerializeField] private GameObject view;
      [SerializeField] private float interest;
    [SerializeField] private float difficult;
    [SerializeField] private int dayviews;
      [SerializeField] private int daylife;
    [SerializeField] private int lvl;
    [SerializeField] private float maxdifficult;


    [SerializeField] private float moneyEffective;

    public string Name { get => nameTheme; set => nameTheme = value; }
      public float Interest { get => interest; set => interest = value; }
      public int Competition { get => competition; set => competition = value; }
      public int Views { get => views; set => views = value; }
      public Sprite Icon { get => icon; set => icon = value; }
      public GameObject View { get => view; set => view = value; }
    public int DayViews { get => dayviews; set => dayviews = value; }
    public List<int> DayviewsList { get => dayviewslist; set => dayviewslist = value; }
    public float MoneyEffective { get => moneyEffective; set => moneyEffective = value; }
    public int Daylife { get => daylife; set => daylife = value; }
    public float Difficult { get => difficult; set => difficult = value; }
    public float Competitionratio { get => competitionratio; set => competitionratio = value; }
    public float Maxdifficult { get => maxdifficult; set => maxdifficult = value; }
    public int Lvl { get => lvl; set => lvl = value; }

    private void Awake()
    {
        
        Icon = ThemeIcons[Random.Range(0, ThemeIcons.Count)];
        Name = ThemeNames[Random.Range(0, ThemeNames.Count)];

        //параметры тем
        if (PlayerPrefs._playerPref.followers > 1000) lvl = PlayerPrefs._playerPref.followers;
        else lvl = 1000;


        competitionratio = Mathf.RoundToInt(Random.Range(0.1f * lvl, lvl));
        
        competition = Mathf.RoundToInt(maxdifficult);
        MoneyEffective = difficult;
    }
}

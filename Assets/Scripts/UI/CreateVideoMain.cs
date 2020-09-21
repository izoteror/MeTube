using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CreateVideoMain : MonoBehaviour
{
    
    public static CreateVideoMain GetDataFromThemeST; // ST - SingleTone
    private ThemeItem currenttheme;
    private string currentVideoName;
    private Sprite currentVideoImage;
    [SerializeField] private RawImage Icon;
    [SerializeField] private Text NameText, InterestName, InfoText, NameChanel;

    public ThemeItem Currenttheme { get => currenttheme; set => currenttheme = value; }
    public string CurrentVideoName { get => currentVideoName; set => currentVideoName = value; }
    public Sprite CurrentVideoImage { get => currentVideoImage; set => currentVideoImage = value; }

    private void Awake()
    {
        if (GetDataFromThemeST != null)
            Destroy(this);
        if (GetDataFromThemeST == null)
            GetDataFromThemeST = this;
        

    }

    private void OnEnable()
    {
        
        CurrentVideoName = "";
        CurrentVideoImage = null;
    }
    public void GetDataFromTheme(ThemeItem theme)
    {
        NameText.text = theme.Name;
        NameChanel.text = PlayerPrefs._playerPref.ChanelName;
        InterestName.text ="Сложность: " +(theme.Interest).ToString("0") + " • дней интереса к теме: " + theme.Daylife;
        InfoText.text = "Количество видео по теме " + theme.Competition + " • Количество просмотров: " + theme.Views;
       // Icon.texture = theme.Icon.texture;
        Currenttheme = theme;
        CurrentVideoImage = Currenttheme.Icon;

    }

    public void GetVideoName(Text name)
    {
        CurrentVideoName = name.text;
    }


    
}

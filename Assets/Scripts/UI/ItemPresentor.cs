using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemPresentor : MonoBehaviour , IPointerClickHandler
{
    public Image Icon;
    public Text text;
    public Text Views;
    [SerializeField] private GameObject _globusindicator;
    private ThemeItem _currenttheme = null;
 


   

    public void Present(ThemeItem item)
    {
        Icon.sprite = item.Icon;
        text.text = item.Name;
        _currenttheme = item;
        Views.text = item.Views.ToString()+ " Запросов • " + item.Daylife + " • дней назад • " + item.Competition+ " • видео по теме ";

        

        var interestcolorsbutton= _globusindicator.gameObject.GetComponent<RawImage>().color;
        interestcolorsbutton= Color.Lerp(Color.red, Color.green, item.Interest/(PlayerPrefs._playerPref.lvl*10));
        _globusindicator.gameObject.GetComponent<RawImage>().color = interestcolorsbutton;
     
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CreateVideoMain.GetDataFromThemeST.GetDataFromTheme(_currenttheme);
        PlayerPrefs._playerPref.currenttheme = _currenttheme;


        TimeManager.ToPause(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ThemeGenerator : MonoBehaviour
{
    public  List<ThemeItem> ThemeList;
    public GameObject ThemePrefab;
    public static ThemeGenerator ThemeGeneratorST;
    private List<GameObject> ThemeObj = new List<GameObject>();
    List<GameObject> DeleteList = new List<GameObject>();


    private void Start()
    {

        if (ThemeGeneratorST != null)
            Destroy(this);
        if (ThemeGeneratorST == null)
            ThemeGeneratorST = this;

        for(int i =0;i<5;i++)
        AddTheme();
        RefreshThemes();
        TimeManager.DayCounterEvent += RefreshThemes;
    }
   
   
    private void DeleteTheme()
    {
        
        foreach (GameObject themeobject in DeleteList)
        {
            Destroy(themeobject.gameObject);
            ThemeObj.Remove(themeobject);
        }
    }

    private void AddTheme()
    {
        GameObject themeobj = Instantiate(ThemePrefab, transform);
        ThemeObj.Add(themeobj);
        themeobj.GetComponent<ItemPresentor>().Present(themeobj.GetComponent<ThemeItem>());

    }

    private void RefreshThemes()
    {

        if (Random.value > 0.8f && ThemeObj.Count <14)
            AddTheme();

        foreach (GameObject themeobject in ThemeObj)
        {
            themeobject.GetComponent<ThemeItem>().Daylife += 1;
            themeobject.GetComponent<BehaviourTheme>().GenerateStats(themeobject.GetComponent<ThemeItem>(), themeobject.GetComponent<ThemeItem>().Daylife);
            themeobject.GetComponent<ItemPresentor>().Present(themeobject.GetComponent<ThemeItem>());

            if (themeobject.GetComponent<ThemeItem>().Interest <= 0)
            {
                
                DeleteList.Add(themeobject);
                
            }
        }

        DeleteTheme();
    }
}

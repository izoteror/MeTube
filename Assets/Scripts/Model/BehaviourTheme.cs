using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTheme : MonoBehaviour
{
    private float ax, ay;
    private float bx, by;
    private float cx, cy;
    private float dx, dy;
    private float X;
    private float Y;
    private float a = 1.0f,b;

     
    private float GenerateCurve(int day, ThemeItem item)
    {
        a = 1.0f;
        a -= 0.025f*day;
        b = 1.0f - a;
        X += 1;
        Y = ay * a * a * a + by * 3 * a * a * b + cy * 3 * a * b * b + dy * b * b * b;
            //изменяем длительность контента
           if (X > dx)
           {
               dx = X;
           }
        return Y;
    }

    public void GenerateStats(ThemeItem item, int day)
    {
        float maxdifficult = PlayerPrefs._playerPref.lvl * 9;// - Mathf.Log(item.Views / PlayerPrefs._playerPref.followers); //9 - count of cards on board * count of turns
        Debug.Log("maxdiff: " + item.Views / PlayerPrefs._playerPref.followers +" itemviews "+item.Views);
        if (maxdifficult < 0) maxdifficult = 1f;
        ax = 0; ay = Random.Range(0.5f*maxdifficult,1.5f*maxdifficult);
        bx = Random.Range(0, 5); by = maxdifficult;
        cx = Random.Range(5, 50) + bx; cy = Random.Range(0.5f * maxdifficult, 1.5f * maxdifficult);
        dx = Random.Range(5, 300) + cx + bx; dy = 0.0f;

        float curveValue = GenerateCurve(day, item);
        Debug.Log("maxdiff: "+maxdifficult+ " curveValue: "+curveValue);
        item.Maxdifficult = maxdifficult;
        CalculateTheme(curveValue,item);



    }

    private void CalculateTheme(float curveValue, ThemeItem item)
    {
        if (curveValue > item.Difficult) item.Difficult = curveValue;
        item.Interest = curveValue;
        int currentcompetition;
        
        
  
        int showperday = Mathf.RoundToInt(item.Competitionratio * curveValue);
        item.Views = showperday;
        if (curveValue > 0)
        {
            currentcompetition = Mathf.RoundToInt(item.Competitionratio / curveValue);
            if (currentcompetition < 0) currentcompetition = 0;
            item.Competition = currentcompetition;
        }
        item.DayViews = showperday;
        
        Debug.Log("showperday " + showperday +" competitonratio "+item.Competitionratio + " competiton " + item.Competition +" Views" +item.Views);
    }
}

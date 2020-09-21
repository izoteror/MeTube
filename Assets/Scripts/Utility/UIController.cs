using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
   private Canvas[] canvases;



    public void ChangeActiveToCanvas(string name)
    { 
        canvases = Resources.FindObjectsOfTypeAll<Canvas>();

        foreach (Canvas canvas in canvases)
        {
            
            if(canvas.name == name)
            {
                canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
            }
           
        }
    }
  
}

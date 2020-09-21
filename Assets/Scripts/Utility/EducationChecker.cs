using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationChecker : MonoBehaviour
{
    public GameObject MainCanvas;
    private void OnEnable()
    {
        MainCanvas.GetComponent<Education>().NextEducationStart();
    }

    private void OnDisable()
    {
        MainCanvas.GetComponent<Education>().EducationEnd();
    }
}

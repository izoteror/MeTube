using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Education : MonoBehaviour
{
    [SerializeField] private GameObject[] _educations;

    private int _educationCount=0;
    private bool _active= true;

    public bool Active { get => _active; set => _active = value; }

    public void NextEducationStart()
    {
        if (Active)
        {
            for (int i = 0; i < _educations.Length; i++)
            {
                if (i == _educationCount)
                {
                    _educations[i].SetActive(true);
                }
            }
        }
    }

    public void EducationCounter()
    {
        _educationCount++;
    }

    public void EducationEnd()
    {
        foreach(GameObject educat in _educations)
        {
            educat.SetActive(false);
        }
    }
    
}

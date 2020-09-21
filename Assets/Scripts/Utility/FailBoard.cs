using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailBoard : MonoBehaviour
{
    [SerializeField] private Text _failText;
    [SerializeField] private GameObject _failPanel;


    public void FailAlarm(string text)
    {
        _failPanel.gameObject.SetActive(true);
        _failText.text = text;
    }
}

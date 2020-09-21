using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStatistic : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cardList;
   
    private void OnEnable()
    {
        for(int i =0; i< _cardList.Count;i++)
        {
            Debug.Log(PlayerPrefs._playerPref._playerCards[i].Name);
            _cardList[i].GetComponent<ElementPresentor>().Present(PlayerPrefs._playerPref._playerCards[i]);
        }
    }
}

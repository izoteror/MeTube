using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UpgradeCardItem : MonoBehaviour, IPointerClickHandler
{
   
    [SerializeField] private string nameofupgrade;
    [SerializeField] private string nameofcard;
    public int card;
    public int scoreToLearn;
    public int currentLearnScore;
    public int price;
    public int index;
    public int _currentstageupgrade;
    public float _effectupgrade;
    public float _percenteffectupgrade;
    public bool done = false;

    public string Nameofupgrade { get => nameofupgrade; set => nameofupgrade = value; }
    

    private void Start()
    {
        nameofcard = PlayerPrefs._playerPref._playerCards[this.card].Name;
        GetComponent<UpgradeCardPresenter>().Presenter(this);
        CardsTree.cardtreeST.SetToList(this);
        if (name == UnityEngine.PlayerPrefs.GetString(name))
        {
            currentLearnScore = UnityEngine.PlayerPrefs.GetInt(name + "score");
            done = PlayerPrefs.GetBoolPlayerPrefs(name + "done");
            GetComponent<UpgradeCardPresenter>().Presenter(this);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CardsTree.cardtreeST.UpgradeCheck(this);
        
    }

    public void Upgrade()
    {
        
        CardsTree.cardtreeST.Upgrade(this);
    }
}

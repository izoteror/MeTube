using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> HandList;
    [SerializeField] private GameObject ChangePanel;
    [SerializeField] private GameObject ChangeCards;
    [SerializeField] private GameObject HandPanel;
    [SerializeField] private GameObject TablePanel;
    [SerializeField] private GameObject FinishButton;
    [SerializeField] private GameObject FightButton;

    public static HandHandler _handhandler;
    private static Transform _handtransform;
    private static Transform _tabletransform;
    private int _currentchangecardscount;
    private int _currentfightconter;


    private void Awake()
    {

        if (_handhandler != null)
            Destroy(this);
        if (_handhandler == null)
            _handhandler = this;

        HandList = new List<GameObject>();
        _handtransform = HandPanel.GetComponent<Transform>();
        _tabletransform = TablePanel.GetComponent<Transform>();
        

    }

    private void OnEnable()
    {
        _currentchangecardscount = GlobalSettings.Changecardscount;
        ChangeCards.SetActive(true);
        ChangeCards.GetComponentInChildren<Text>().text = "Сменить карты: " + _currentchangecardscount;

        _currentfightconter = 1;
        FinishButton.SetActive(false);
        FightButton.SetActive(true);
        FightButton.GetComponentInChildren<Text>().text = "Записать часть  " + _currentfightconter;
    }

    public void AddToHand(ElementModel card)
    {
        if(HandList.Count<GlobalSettings.Maxhandcounter)
        {
            HandList.Add(card.gameObject);
            card.gameObject.transform.parent = _handtransform;
            ChangePanel.GetComponent<ChangeCardHandler>().ElementObj.Remove(card.gameObject);
            ChangePanel.GetComponent<ChangeCardHandler>().ElementList.Remove(card._currentelement);
        }
        
        
    }

    public void AddToChanger(ElementModel card)
    {
        ChangePanel.GetComponent<ChangeCardHandler>().ElementList.Add(card._currentelement);
    }

    public void AddToTable(ElementModel card)
    {
        if (TablePanel.GetComponent<TablePlaySystem>()._tableElements.Count < GlobalSettings.Maxtablecounter)
        {
            if (card._currentelement.Type == 3)
            {
               ElementModel checkcard = TablePanel.GetComponent<TablePlaySystem>()._tableElements.Find(delegate (ElementModel res)
                {
                    return res._currentelement.Type == 2;
                });
                if (checkcard)
                {
                    card.gameObject.transform.parent = _tabletransform;
                    TablePanel.GetComponent<TablePlaySystem>()._tableElements.Add(card);

                    HandList.Remove(card.gameObject);
                }
            }
            else
            {
                card.gameObject.transform.parent = _tabletransform;
                TablePanel.GetComponent<TablePlaySystem>()._tableElements.Add(card);

                HandList.Remove(card.gameObject);
            }
        }
    }
    public  void CardMover(ElementModel card)
    {

        if (card.gameObject.transform.parent == transform)
        {
           AddToTable(card);   
        }

        else
        {
            AddToHand(card);
        }

        

    }

    public void ChangeCard()
    {
        

        if (_currentchangecardscount <=1)
        {
            ChangePanel.GetComponent<ChangeCardHandler>().RefreshCards();
            ChangeCards.SetActive(false);

        }
        else
        {
            _currentchangecardscount--;
            ChangePanel.GetComponent<ChangeCardHandler>().RefreshCards();
            
        }
        ChangeCards.GetComponentInChildren<Text>().text = "Сменить карты: " + _currentchangecardscount;
    }

    public void Fight()
    {


        if (_currentfightconter >= GlobalSettings.Fightstepscount)
        {
            TablePanel.GetComponent<TablePlaySystem>().TableFight();
            ChangePanel.GetComponent<ChangeCardHandler>().RefreshCards();
            FinishButton.SetActive(true);
            FightButton.SetActive(false);
            

        }
        else
        {
            _currentfightconter++;
            TablePanel.GetComponent<TablePlaySystem>().TableFight();
            ChangePanel.GetComponent<ChangeCardHandler>().RefreshCards();

        }
        FightButton.GetComponentInChildren<Text>().text = "Записать часть " + _currentfightconter;
    }

    public void HandCardDestroy()
    {
        foreach(GameObject card in HandList)
        {
           AddToChanger(card.GetComponent<ElementModel>());
            Destroy(card);
        }

        HandList.Clear();
    }


}
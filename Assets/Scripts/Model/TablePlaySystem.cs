using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablePlaySystem : MonoBehaviour
{

    public List<ElementModel> _tableElements;
    public List<ElementModel> _buffCardList;
    public List<ElementModel> _atackCardList;
    public List<ElementModel> _supportCardList;

   
    private GameObject _tablePanel;
    private float _damage;
 


    void Start()
    {
        _tablePanel = this.gameObject;
       
    }
    private void OnEnable()
    {
        _tableElements.Clear();
        _damage = 0;
        this.GetComponent<GoalPresenter>().SwitcherSlider(true);
        this.GetComponent<GoalPresenter>().UpdateSlider(_damage);
    }

    public void TableFight()
    {
       
        foreach (ElementModel card in _tableElements)
        {
            if (card._currentelement.Type == 1)
                _buffCardList.Add(card);
            else if (card._currentelement.Type == 2)
            { 
                _atackCardList.Add(card);
            }
            else if (card._currentelement.Type == 3)
                _supportCardList.Add(card);
        }

       
        if (_buffCardList.Count > 0)
        {
           foreach(ElementModel atackcard in _atackCardList)
            {
                float unbuffedEffect = atackcard._currentelement.Effect;
                float unbuffedPercent = atackcard._currentelement.PercentEffect;

                atackcard._currentelement = DoBuff(atackcard);
                DoDamage(atackcard);

                atackcard._currentelement.Effect = unbuffedEffect;
                atackcard._currentelement.PercentEffect = unbuffedPercent;

                CardReturnToChanger(atackcard);
            }
        }
        else if (_atackCardList.Count> 0)
        {
            foreach (ElementModel atackcard in _atackCardList)
            {
                DoDamage(atackcard);
                CardReturnToChanger(atackcard);
            }
        }

        this.GetComponent<GoalPresenter>().UpdateSlider(_damage);
        
        _buffCardList.Clear();
        _atackCardList.Clear();
        _supportCardList.Clear();
        
    }

    private void DoSupport(ElementModel atackcard, bool atackfail)
    {
        if (_supportCardList.Count > 0)
        {
            foreach (ElementModel suppcard in _supportCardList)
            {
                if (suppcard._currentelement.Stage == 1)
                {
                    
                    if (_damage == 0)
                        _damage += suppcard._currentelement.Effect;
                   
                }
                if (suppcard._currentelement.Stage == 2 && atackfail)
                {
                    _damage += atackcard._currentelement.Effect* suppcard._currentelement.PercentEffect;
                   
                }
                if (suppcard._currentelement.Stage == 3 && !atackfail)
                {
                    _damage += _damage * suppcard._currentelement.PercentEffect;
                    
                }
                CardReturnToChanger(suppcard);
            }
            
        }
    }

    private void DoDamage(ElementModel atackcard)
    {
        int dice = UnityEngine.Random.Range(0,100);
        if (atackcard._currentelement.PercentEffect * 100 > dice)
        {
            _damage += atackcard._currentelement.Effect;
            DoSupport(atackcard, false);
        }
        else
        {
            DoSupport(atackcard, true);
        }
    }

    public Element DoBuff(ElementModel atackcard)
    {
        
        foreach (ElementModel buffcard in _buffCardList)
        {
            if (atackcard._currentelement.Stage == 1 && buffcard._currentelement.Stage == 1)
            {
                atackcard._currentelement.Effect += atackcard._currentelement.Effect * buffcard._currentelement.Effect;

            }
            else if (atackcard._currentelement.Stage == 2 && buffcard._currentelement.Stage == 2)
            {
                atackcard._currentelement.PercentEffect += buffcard._currentelement.PercentEffect;
            }
            CardReturnToChanger(buffcard);
        }
        return atackcard._currentelement;
    }

    public void Finish()
    {
       
        VideoManager.videomanagerST.CreateVideo(_damage);
        
        HandHandler._handhandler.HandCardDestroy();
        foreach(ElementModel card in _tableElements)
        {
            CardReturnToChanger(card);
        }
        _tableElements.Clear();

    }
    private void CardReturnToChanger(ElementModel card)
    {
        
            HandHandler._handhandler.AddToChanger(card);
            Destroy(card.gameObject);
            _tableElements.Remove(card);
    }
}

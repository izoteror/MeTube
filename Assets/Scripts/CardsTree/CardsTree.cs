using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsTree : MonoBehaviour
{

    private List<UpgradeCardItem> upgradeListCard = new List<UpgradeCardItem>();
    [SerializeField] private GameObject _payToUpgradePanel;
    
    
     

    public static CardsTree cardtreeST;

    public List<UpgradeCardItem> UpgradeListCard { get => upgradeListCard; set => upgradeListCard = value; }

    private void Awake()
    {
        if (cardtreeST != null)
            Destroy(this);
        if (cardtreeST == null)
            cardtreeST = this;
        
       
    }
    public void SetToList(UpgradeCardItem upgrade)
    {

        UpgradeListCard.Add(upgrade);

    }

    public void UpgradeCheck(UpgradeCardItem currentupgrade)
    {
        List<UpgradeCardItem> resultlist = UpgradeListCard.FindAll(delegate (UpgradeCardItem res)
        {
            return (res.card == currentupgrade.card && res.index == currentupgrade.index - 1);
        });

        if (resultlist.Count != 0)
        {
            foreach (UpgradeCardItem result in resultlist)
            {
                if (result.done && !currentupgrade.done)
                {
                    PayToUpgrade(currentupgrade);
                }
                else if(!currentupgrade.done) Camera.main.GetComponent<FailBoard>().FailAlarm("Прокачайте предыдущие навыки");
            }
        }
        else if (!currentupgrade.done)
        {
            PayToUpgrade(currentupgrade);
        }
        
    }

    public void PayToUpgrade(UpgradeCardItem currentupgrade)
    {
        if (PlayerPrefs._playerPref.money >= currentupgrade.price)
        {
            PlayerPrefs._playerPref.money -= currentupgrade.price;
            _payToUpgradePanel.gameObject.transform.parent.gameObject.SetActive(true);
            _payToUpgradePanel.GetComponent<PayToUpgradeSystem>().PayToUpgrade(currentupgrade);
        }
        else
        {
            Camera.main.GetComponent<FailBoard>().FailAlarm("У вас недостаточно денег!");
        }
    }

    public void Upgrade(UpgradeCardItem currentupgrade)
    {
        Element _currentelement = PlayerPrefs._playerPref._playerCards[currentupgrade.card];

        _currentelement.Effect += currentupgrade._effectupgrade;
        _currentelement.PercentEffect += currentupgrade._currentstageupgrade;
        currentupgrade.done = true;
        currentupgrade.GetComponent<UpgradeCardPresenter>().Presenter(currentupgrade);

    }
}

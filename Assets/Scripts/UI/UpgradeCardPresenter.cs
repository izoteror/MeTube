using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCardPresenter : MonoBehaviour
{
    private UpgradeCardItem _currentupgradecard;
    [SerializeField] private Text _upgradecardname;
    [SerializeField] private Text _nameofcard;
    [SerializeField] private Toggle _donetoggle;


    public void Presenter(UpgradeCardItem currentupdgradecard)
    {
        _currentupgradecard = currentupdgradecard;
        _donetoggle.isOn = _currentupgradecard.done;
        _upgradecardname.text = _currentupgradecard.Nameofupgrade;

        _nameofcard.text = PlayerPrefs._playerPref._playerCards[_currentupgradecard.card].Name;
    }

}

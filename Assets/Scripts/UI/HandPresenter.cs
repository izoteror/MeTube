using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandPresenter : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Icon;
    public Text NameText;
    public Text EffectText;
    public Text SuitText;
    public Text CostText;

    private Element _currentelement = null;





    public void Present(Element item)
    {
        Icon.sprite = item.Icon;
        EffectText.text = item.Effect.ToString();
        SuitText.text = item.Suit.ToString();
        CostText.text = item.Stage.ToString();
        NameText.text = item.Name;
        _currentelement = item;
        EffectText.text = item.Effect.ToString();





    }
}

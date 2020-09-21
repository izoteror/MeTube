using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementModel : MonoBehaviour, IPointerClickHandler
{
    public GameObject ElementPrefab;
    public Element _currentelement = null;




    public void Model(Element item)
    {
        _currentelement = item;
    }

    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        HandHandler._handhandler.CardMover(this);
    }


}

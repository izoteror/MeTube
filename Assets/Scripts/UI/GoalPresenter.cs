using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalPresenter : MonoBehaviour
{
   
    [SerializeField] private Slider _damage;
    private void OnEnable()
    {
        _damage.minValue = 0;
        _damage.maxValue = CreateVideoMain.GetDataFromThemeST.Currenttheme.Interest;
       
    }
    
    public void UpdateSlider(float value)
    {
        _damage.value = value;
    }    

    public void SwitcherSlider(bool state)
    {
        _damage.gameObject.SetActive(state);
    }
}

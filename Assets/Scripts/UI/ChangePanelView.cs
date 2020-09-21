using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanelView : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangePanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}

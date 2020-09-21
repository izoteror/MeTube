using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
    }
}

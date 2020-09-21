using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeItemStatGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float interest;
    [SerializeField] private List<Sprite> Icons;

    private void Awake()
    {
        interest = Random.Range(0.1f, 1f);

    }
}

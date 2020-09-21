using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Element
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _view;
    [SerializeField] private string _nameElement;
    [SerializeField] private int _suit;
    [SerializeField] private int _type;
    [SerializeField] private int _stage;
    [SerializeField] private float _effect;
    [SerializeField] private float _percenteffect;
    [SerializeField] private string _commentElement;


    public string Name { get => _nameElement; set => _nameElement = value; }
    public int Suit { get => _suit; set => _suit = value; }
    public int Type { get => _type; set => _type = value; }
    public float Effect { get => _effect; set => _effect = value; }
    public int Stage { get => _stage; set => _stage = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public GameObject View { get => _view; set => _view = value; }
    public float PercentEffect { get => _percenteffect; set => _percenteffect = value; }
    public string CommentElement { get => _commentElement; set => _commentElement = value; }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementPresentor : MonoBehaviour 
{
    // Start is called before the first frame update
   [SerializeField] private Image Icon;
   [SerializeField] private Image Back;
   [SerializeField] private Text NameText;
   [SerializeField] private Text CommentText;
   [SerializeField] private Text PercentText;
   [SerializeField] private Text AtackText;
   [SerializeField] private Sprite[] IconSprite;
   [SerializeField] private Color[] BackColor;

   
    
    private Element _currentelement = null;

   



    public void Present(Element item)
    {
        for(int i=0;i<IconSprite.Length;i++)
        {
            if (i == item.Suit)
            {                
                Back.color = new Color(BackColor[i].r, BackColor[i].g, BackColor[i].b);
            }
        }
         
        Icon.sprite = item.Icon;
       
        CommentText.text =item.CommentElement;

        NameText.text = item.Name;
        

        PercentText.text = (item.PercentEffect)*100 +"%";
        AtackText.text = item.Effect.ToString();
        _currentelement = item;

    }
   
}

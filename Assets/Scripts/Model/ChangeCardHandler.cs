using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCardHandler : MonoBehaviour
{


    private List<Element> elementList;
    [SerializeField] private GameObject elementPrefab;
    private List<GameObject> elementObj = new List<GameObject>();
    private List<GameObject> deleteList = new List<GameObject>();

    public List<Element> ElementList { get => elementList; set => elementList = value; }
    public GameObject ElementPrefab { get => elementPrefab; set => elementPrefab = value; }
    public List<GameObject> ElementObj { get => elementObj; set => elementObj = value; }
    public List<GameObject> DeleteList { get => deleteList; set => deleteList = value; }

    private void Awake()
    {

        ElementList = PlayerPrefs._playerPref._playerCards;
        List<Element> TempListElement = new List<Element>();
        foreach(Element element in ElementList)
        {
            TempListElement.Add(element);
            TempListElement.Add(element);
            TempListElement.Add(element);
        }
        ElementList = TempListElement;
        
    }
    private void Start()
    {
        
       
        for (int i = 0; i < 5; i++)
        {
            AddElement(ElementList[Random.Range(0, ElementList.Count)]);
        }

    }


    private void ClearElementList()
    {

        foreach (GameObject themeobject in DeleteList)
        {
            Destroy(themeobject.gameObject);
            ElementObj.Remove(themeobject);
        }
    }



    private void AddElement(Element element)
    {
        GameObject elementobj = Instantiate(ElementPrefab, transform);
        ElementObj.Add(elementobj);
        elementobj.GetComponent<ElementPresentor>().Present(element);
        elementobj.GetComponent<ElementModel>().Model(element);
    }

    public void RefreshCards()
    {
        
       
            foreach (GameObject elementobject in ElementObj)
            {

                DeleteList.Add(elementobject);

            }

            ClearElementList();


            for (int i = 0; i < 5; i++)
            {
                AddElement(ElementList[Random.Range(0, ElementList.Count)]);
            }
            
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementGenerator : MonoBehaviour
{
    public List<Element> ElementList;
    public GameObject ElementPrefab;
    public List<GameObject> ElementObj = new List<GameObject>();
    List<GameObject> DeleteList = new List<GameObject>();


    private void Start()
    {

        foreach(Element element in ElementList)
        {       
            GameObject elementobj = Instantiate(ElementPrefab, transform);
            ElementObj.Add(elementobj);
            elementobj.GetComponent<ElementPresentor>().Present(element);
            elementobj.GetComponent<ElementModel>().Model(element);
        }
        TimeManager.DayCounterEvent += RefreshThemes;
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

    private void RefreshThemes()
    {
        

        foreach (GameObject elementobject in ElementObj)
        {
           
           

                DeleteList.Add(elementobject);

            
        }

        ClearElementList();


        foreach(Element element in ElementList)
            AddElement(ElementList[Random.Range(0, ElementList.Count)]);

    }
}

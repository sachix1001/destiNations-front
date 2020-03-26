using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScavengerHunt : MonoBehaviour, IPointerDownHandler
{
    public GameObject UI;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;
    public GameObject answer1text;
    public GameObject answer2text;
    public GameObject answer3text;

    public string countryname1;
    public string countryname2;
    public string countryname3;
    public string animal;
    public string language;
    public string flag;
    List<string> countries;
    public static string CC;

    public void OnPointerDown(PointerEventData eventData) {
     UI = GameObject.Find("/UIComponents");

                    countries = new List<string>();
                    countries.Add(countryname1);
                    countries.Add(countryname2);
                    countries.Add(countryname3);

                    for (int str = 0; str < countries.Count; str++) {
                    // foreach (string str in countries) {
                        if (countries[str] == "Philippines") 
                        {
                            countries[str] = "The " + countries[str]; 
                        }
                        if (countries[str] == "United States of America") 
                        {
                            countries[str] = "The United States";
                        }
                        if (countries[str] == "United Kingdom of Great Britain and Northern Ireland") 
                        {
                            countries[str] = "The United Kingdom";
                        }
                        if (countries[str] == "Russian Federation") 
                        {
                            countries[str] = "Russia";
                        }
                        if (countries[str] == "Korea (Republic of)") 
                        {
                            countries[str] = "South Korea";
                        }
                    }
                        countryname1 = countries[0];
                        countryname2 = countries[1];
                        countryname3 = countries[2];
     
    Transform uiTr = UI.transform;
    Transform a1 = answer1text.transform;
    Transform a2 = answer2text.transform;
    Transform a3 = answer3text.transform;

    foreach (Transform child in uiTr)
        {
            if (child.tag == "scavengerQuestions")
            {
                foreach (Transform grandchild in child) 
                {
                    if (grandchild.tag == "question1") 
                    {
                        foreach (Transform ggrandchild in grandchild) 
                        {
                            if (a1.GetComponent<UnityEngine.UI.Text>().text == "?") 
                            {
                        ggrandchild.GetComponent<UnityEngine.UI.Text>().text = $"Find a plane going to a country whose national animal is the {animal}.";
                            }
                        }
                        
                    }
                    if (grandchild.tag == "question2") 
                    {
                        foreach (Transform ggrandchild in grandchild) 
                        {
                            if (a2.GetComponent<UnityEngine.UI.Text>().text == "?") 
                            {
                            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = $"Find a plane going to a country where people speak {language}.";
                            }
                        }
                    }
                    if (grandchild.tag == "question3") 
                    {
                        grandchild.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"{flag}");
                        grandchild.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = $"Find a plane going to a country whose flag looks like this.";
                        //foreach (Transform ggrandchild in grandchild)
                        //{
                        //    if (a3.GetComponent<UnityEngine.UI.Text>().text == "?") 
                        //    {
                        //        if (ggrandchild.tag == "flagImg")
                        //        {
                        //            ggrandchild.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{flag}");
                        //            //ggrandchild.GetComponent<Image>().sprite = Resources.Load<Sprite>(CC);
                        //            //Debug.Log("CC " + CC);
                        //            //Debug.Log("previous flag code: " + flag);
                        //        }
                        //        if (ggrandchild.tag == "question3")
                        //        {
                        //            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = $"Find a plane going to a country whose flag looks like this.";
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }
    }
}

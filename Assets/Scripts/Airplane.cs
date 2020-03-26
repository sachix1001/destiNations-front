using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Airplane : MonoBehaviour, IPointerDownHandler
{
    public string ccTo;
    public string ccFrom;
    public string countryName;
    public string language;
    public string countryname2;
    public string greeting;
    public string flag;
    public string animal;
    public Image flagImage;
    private Texture2D texture;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public int ShapeID { get; set; } = int.MinValue;
    public GameObject CountryCanvas;
    public GameObject UI;
    public GameObject alert;
    public GameObject hunt;
    public bool question1 = false;
    public bool question2 = false;
    public bool question3 = false;
    public bool first1 = true;
    public bool first2 = true;
    public bool first3 = true;
    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        playClip();
        UI = GameObject.Find("/UIComponents");
        alert = GameObject.Find("/UIComponents/ScavengerHunt/alertHunt");
        hunt = GameObject.Find("/UIComponents/ScavengerHunt/huntImg");
        countryname2 = hunt.GetComponent<ScavengerHunt>().countryname2;
        Transform uiTr = UI.transform;
        foreach (Transform child in uiTr)
        {
            // if (child.tag == "fullScreenFacts")
            // {
            //     foreach (Transform grandchild in child)
            //     {
            //         if (grandchild.tag == "Button")
            //         {
            //             grandchild.SetActive(showButton);
            //         }
            //     }
            // }
            if (child.tag == "CountryFacts")
            {
                foreach (Transform grandchild in child)
                {
                    if (countryName == "Philippines")
                    {
                        countryName = "The " + countryName;
                    }
                    if (countryName == "United States of America")
                    {
                        countryName = "The United States";
                    }
                    if (countryName == "United Kingdom of Great Britain and Northern Ireland")
                    {
                        countryName = "The United Kingdom";
                    }
                    if (countryName == "Russian Federation")
                    {
                        countryName = "Russia";
                    }
                    if (countryName == "Korea (Republic of)")
                    {
                        countryName = "South Korea";
                    }
                    if (grandchild.tag == "mainText")
                    {
                        // name of the country
                        grandchild.GetComponent<UnityEngine.UI.Text>().text = $"This plane is on its way to...\r\n{countryName}!";
                    }
                    if (grandchild.tag == "someFacts")
                    {
                        foreach (Transform ggrandchild in grandchild)
                        {
                            // some facts about COUNTRYNAME
                            // if (ggrandchild.tag == "someFacts")
                            // {
                            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = $"Learn more about\r\n{countryName}?";
                        }
                        //}
                    }
                    if (grandchild.tag == "flagImg")
                    {
                        grandchild.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{ccTo}");
                    }
                    child.gameObject.SetActive(true);
                    if (grandchild.tag == "close")
                    {
                        grandchild.gameObject.SetActive(true);
                    }
                }
            }
            if (child.tag == "fullScreenFacts")
            {
                if (animal == hunt.GetComponent<ScavengerHunt>().animal)
                {
                    question1 = true;
                    if (first1 == true)
                    {
                        first1 = false;
                        alert.SetActive(true);
                    }
                }
                if (language == hunt.GetComponent<ScavengerHunt>().language && countryname2 == hunt.GetComponent<ScavengerHunt>().countryname2 )
                {
                    question2 = true;
                    if (first2 == true)
                    {
                        first2 = false;
                        alert.SetActive(true);
                    }
                }
                if (ccTo == hunt.GetComponent<ScavengerHunt>().flag)
                {
                    question3 = true;
                    if (first3 == true)
                    {
                        first3 = false;
                        alert.SetActive(true);
                    }
                }
                foreach (Transform grandchild in child)
                {
                    if (grandchild.tag == "titleLarge")
                    {
                        grandchild.GetComponent<UnityEngine.UI.Text>().text = $"Learn about\r\n{countryName}:";
                    }
                    if (grandchild.tag == "funFact")
                    {
                        grandchild.GetComponent<UnityEngine.UI.Text>().text = $"The national animal of {countryName} is the {animal}.";
                    }
                    if (grandchild.tag == "flagImg")
                    {
                        grandchild.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{ccTo}");
                    }
                    if (grandchild.tag == "flagImg")
                    {
                        grandchild.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{ccTo}");
                    }
                    if (grandchild.tag == "languagesSpoken")
                    {
                        grandchild.GetComponent<UnityEngine.UI.Text>().text = $"In {countryName}, we speak {language}.";
                    }
                    foreach (Transform ggrandchild in grandchild)
                    {
                        if (ggrandchild.tag == "greeting")
                        {
                            // greeting = greeting.Replace("&#", "\u");
                            greeting =
                            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = $"{greeting}!";
                        }
                    }
                }
            }
            if (child.tag == "scavengerQuestions")
            {
                {
                    foreach (Transform grandchild in child)
                    {
                        if (question1)
                        {
                            if (grandchild.tag == "answerOne")
                            {
                                // Debug.Log("One");
                                foreach (Transform ggrandchild in grandchild)
                                {
                                    if (ggrandchild.tag == "Text")
                                    {
                                        if (ggrandchild.GetComponent<UnityEngine.UI.Text>().text != "added!")
                                        {
                                            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = "click me!";
                                            ggrandchild.GetComponent<UnityEngine.UI.Text>().fontSize = 16;
                                        }
                                    }
                                }
                            }
                        }
                        if (question2)
                        {
                            if (grandchild.tag == "answerTwo")
                            {
                                // Debug.Log("Two");
                                foreach (Transform ggrandchild in grandchild)
                                {
                                    if (ggrandchild.tag == "Text")
                                    {
                                        if (ggrandchild.GetComponent<UnityEngine.UI.Text>().text != "added!")
                                        {
                                            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = "click me!";
                                            ggrandchild.GetComponent<UnityEngine.UI.Text>().fontSize = 16;
                                        }
                                    }
                                }
                            }
                        }
                        if (question3)
                        {
                            if (grandchild.tag == "answerThree")
                            {
                                // Debug.Log("Three");
                                foreach (Transform ggrandchild in grandchild)
                                {
                                    if (ggrandchild.tag == "Text")
                                    {
                                        if (ggrandchild.GetComponent<UnityEngine.UI.Text>().text != "added!")
                                        {
                                            ggrandchild.GetComponent<UnityEngine.UI.Text>().text = "click me!";
                                            ggrandchild.GetComponent<UnityEngine.UI.Text>().fontSize = 16;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
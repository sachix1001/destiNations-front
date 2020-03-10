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
    public string flag;
    public Image flagImage;
    private Texture2D texture;

    public int ShapeID { get; set; } = int.MinValue;
    public GameObject CountryCanvas;
    public GameObject UI;

    public void OnPointerDown(PointerEventData eventData)
    {
        UI = GameObject.Find("/UIComponents");
        Transform uiTr = UI.transform;
        foreach (Transform child in uiTr)
        {
            if (child.tag == "CountryFacts")
            {
                foreach (Transform grandchild in child)
                {
                    if (grandchild.tag == "mainText")
                    {
                        // name of the country
                        grandchild.GetComponent<UnityEngine.UI.Text>().text = countryName;
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
        }
    }
}

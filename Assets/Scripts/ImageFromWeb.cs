using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFromWWW : MonoBehaviour
{
    public string url = "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Flag_of_India.svg/255px-Flag_of_India.svg.png";
    public Renderer thisRenderer;

    private void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine()); // execute the section on click

        // the following will be called even before the load finishes
        thisRenderer.material.color = Color.red;
    }



    private IEnumerator LoadFromLikeCoroutine()
    {
        Debug.Log("Loading ...");
        WWW wwwLoader = new WWW(url); // create WWW object pointing to the url
        yield return wwwLoader;  // start loading whatever in that url (delay happens here)

        Debug.Log("Loaded");
        thisRenderer.material.color = Color.black;
        thisRenderer.material.mainTexture = wwwLoader.texture; // set loaded image
    }

}
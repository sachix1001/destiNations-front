using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using System.Collections;


public class OpenedPassport : MonoBehaviour
{
    public GameObject passport;
    public static string Id;
    List<string> countries = new List<string>();
    bool isDisplayed;
    public GameObject cloneFlag;
    public GameObject alert;

    public void Start()
    {
        isDisplayed = false;
    }

    public void createFlag()
    {
        alert = GameObject.Find("/UIComponents/Passport/passImg/alertPass");
        alert.SetActive(false);
        countries.Clear();
        StartCoroutine(displayPassport());
    }

    private IEnumerator displayPassport()
    {

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://destinations-925e3.firebaseio.com/");
        FirebaseDatabase.DefaultInstance
            .GetReference("Users")
            .Child(Id)
            .Child("Countries")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("error");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (var country in snapshot.Children)
                    {
                        countries.Add(country.Value.ToString());
                        

                    }
                }

            });
        yield return new WaitForSeconds(1);

            passport = GameObject.FindGameObjectWithTag("flags");
            Debug.Log(countries.Count);
            for (int i = 0; i < countries.Count; i++)
            {

                int j = i / 6;
                int k = i % 6;

                GameObject obj = (GameObject)Resources.Load("Flag");
                //GameObject
                cloneFlag = Instantiate(obj);

                cloneFlag.transform.SetParent(passport.transform, false);
                RectTransform rectTransform = cloneFlag.GetComponent<RectTransform>();
                rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10 + 100 * k, rectTransform.rect.width);
                rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 60 * j, rectTransform.rect.height);
                cloneFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{countries[i]}");
            RectTransform rt = passport.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(0, 60 * (j + 1));
            }
        isDisplayed = true;
        }
}
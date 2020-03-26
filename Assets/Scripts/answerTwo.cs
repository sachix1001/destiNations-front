using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class answerTwo : MonoBehaviour
{
     public GameObject answer2;
     public GameObject answer2text;
     public GameObject question2;
     public GameObject hunt;
     public GameObject passport;
     public string language;
     public string countryname2;
     public static string Id;
     public static string countryCode;
     public GameObject alert;

    // Start is called before the first frame update
    public void clicked () {
     hunt = GameObject.Find("/UIComponents/ScavengerHunt/huntImg");
     passport = GameObject.Find("/UIComponents/scavengerQuestions/answerTwo/passport");
     language = hunt.GetComponent<ScavengerHunt>().language;
     countryname2 = hunt.GetComponent<ScavengerHunt>().countryname2;

        if (answer2text.GetComponent<UnityEngine.UI.Text>().text == "click me!") {
        question2.GetComponent<UnityEngine.UI.Text>().text = $"You found a plane going to {countryname2}! In {countryname2}, a lot of people speak {language}.";
        }
    }

        public void alertClicked () {
        alert = GameObject.Find("/UIComponents/Passport/passImg/alertPass");
        if (passport.activeSelf)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Users").Child(Id).Child("Countries").Push().SetValueAsync(countryCode);
            alert.SetActive(true);
            answer2text.GetComponent<UnityEngine.UI.Text>().text = "added!";
            passport.SetActive(false);
        }
        if (answer2text.GetComponent<UnityEngine.UI.Text>().text == "click me!") 
        {
            passport.SetActive(true);
        }
    }
}

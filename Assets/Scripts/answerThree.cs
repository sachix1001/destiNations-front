using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class answerThree : MonoBehaviour
{
     public GameObject answer3;
     public GameObject answer3text;
     public GameObject question3;
     public GameObject hunt;
     public GameObject passport;
     public string countryname3;
     public static string Id;
     public static string countryCode;
     public GameObject alert;

    // Start is called before the first frame update
    public void clicked () {
     hunt = GameObject.Find("/UIComponents/ScavengerHunt/huntImg");
     passport = GameObject.Find("/UIComponents/scavengerQuestions/answerThree/passport");
     countryname3 = hunt.GetComponent<ScavengerHunt>().countryname3;

        if (answer3text.GetComponent<UnityEngine.UI.Text>().text == "click me!") {
   
        question3.GetComponent<UnityEngine.UI.Text>().text = $"You found a plane going to {countryname3}! {countryname3}'s flag looks like this:";
        }
    }

    public void alertClicked () {
        alert = GameObject.Find("/UIComponents/Passport/passImg/alertPass");
        if (passport.activeSelf)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Users").Child(Id).Child("Countries").Push().SetValueAsync(countryCode);
            alert.SetActive(true);
            answer3text.GetComponent<UnityEngine.UI.Text>().text = "added!";
            passport.SetActive(false);
        }
        if (answer3text.GetComponent<UnityEngine.UI.Text>().text == "click me!") 
        {
            passport.SetActive(true);
        }
    }
}

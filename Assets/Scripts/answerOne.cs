using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class answerOne : MonoBehaviour
{
     public GameObject answer1;
     public GameObject answer1text;
     public GameObject question1;
     public GameObject hunt;
     public GameObject passport;
     public string animal;
     public string countryname1;
     public static string Id;
     public static string countryCode;
     public GameObject alert;

    // Start is called before the first frame update

    public void clicked () {
     hunt = GameObject.Find("/UIComponents/ScavengerHunt/huntImg");
     passport = GameObject.Find("/UIComponents/scavengerQuestions/answerOne/passport");
     animal = hunt.GetComponent<ScavengerHunt>().animal;
     countryname1 = hunt.GetComponent<ScavengerHunt>().countryname1;

        if (answer1text.GetComponent<UnityEngine.UI.Text>().text == "click me!") {
        question1.GetComponent<UnityEngine.UI.Text>().text = $"You found a plane going to {countryname1}! {countryname1}'s national animal is the {animal}.";
        }
    }

    public void alertClicked () {
        alert = GameObject.Find("/UIComponents/Passport/passImg/alertPass");
        if (passport.activeSelf)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Users").Child(Id).Child("Countries").Push().SetValueAsync(countryCode);
            alert.SetActive(true);
            answer1text.GetComponent<UnityEngine.UI.Text>().text = "added!";
            passport.SetActive(false);
        }
        if (answer1text.GetComponent<UnityEngine.UI.Text>().text == "click me!") 
        {
            passport.SetActive(true);
            
        }
    }
}

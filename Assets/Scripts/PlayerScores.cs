using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    Firebase.Auth.FirebaseUser user;
    public static string Id;

    void Awake()
    {

        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

            auth.SignInAnonymouslyAsync().ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInAnonymouslyAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                    AggregateException ex = task.Exception as AggregateException;
                    if (ex != null)
                    {
                        Firebase.FirebaseException fbEx = null;
                        foreach (Exception e in ex.InnerExceptions)
                        {
                            fbEx = e as Firebase.FirebaseException;
                            if (fbEx != null)
                                break;
                        }

                        if (fbEx != null)
                        {
                            Debug.LogError("Encountered a FirebaseException:" + fbEx.Message);
                        }
                    }
                    //Firebase.FirebaseApp.LogLevel = Firebase.LogLevel.Debug;
                    return;
                }

                user = task.Result;
                Passport.Id = user.UserId;
                OpenedPassport.Id = user.UserId;
                answerOne.Id = user.UserId;
                answerTwo.Id = user.UserId;
                answerThree.Id = user.UserId;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                                    user.DisplayName, user.UserId);
            });
    }
}
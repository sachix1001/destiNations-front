using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;
public class UserAuthentication : MonoBehaviour
{
    public Firebase.Auth.FirebaseUser user;

    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://destinations-925e3.firebaseio.com/");
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser == null)
        {
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
                        FirebaseException fbEx = null;
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
                    Firebase.FirebaseApp.LogLevel = Firebase.LogLevel.Debug;
                    return;
                }
                user = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    user.DisplayName, user.UserId);
            });
        }
        else
        {
            user = auth.CurrentUser;
            Debug.Log("User is signed already signed in" + user.UserId);
        }
        
    }
}
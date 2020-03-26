using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPosition : MonoBehaviour
{
    public GameObject globe;
    public void originalPosition() {
        globe = GameObject.Find("/earth/Icosphere");
        globe.transform.rotation = Quaternion.Euler(-120f, -50f, 0f);
        // globe.transform.position = new Vector3(10f, 10f, 10f);
<<<<<<< HEAD:Assets/Scripts/EarthPosition.cs
        globe.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
=======
>>>>>>> 5750b0e38bb0951d697458e2a03317c82d6cdb8d:Assets/Scripts/EarthPosition.cs
    }

}

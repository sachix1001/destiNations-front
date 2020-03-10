using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class FirstArc : MonoBehaviour
{
    public VectorLine arcLine;
    public List<Vector3> linePoints;
    // Start is called before the first frame update
    void Start()
    {
        arcLine = new VectorLine("Line", linePoints, 2.0f);
        linePoints = new List<Vector3>() { new Vector3(20, 30, 0), new Vector3(100, 50, 1) };
        arcLine.MakeArc(Vector3.zero, 0, 0, 45.0f, 315.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

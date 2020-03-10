using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;
public class Arc : MonoBehaviour
{
    public VectorLine arc;
    public GameObject departure;
    public GameObject destination;
    public GameObject plane;
    public int segments = 10;
    public bool loop = true;
    public GameObject earth;
    public Vector3 direction;
    private VectorLine spline;
    // Start is called before the first frame update
    void Start()
    {
        departure = GameObject.FindGameObjectWithTag("ZA");
        destination = GameObject.FindGameObjectWithTag("TR");
        plane = GameObject.FindGameObjectWithTag("Player");
        earth = GameObject.FindGameObjectWithTag("Earth");
        Vector3 midpoint = (departure.transform.position + destination.transform.position) * 0.5f;
        plane.transform.position = Vector3.MoveTowards(midpoint, earth.transform.position, -6f);
        //set plane orientation
        plane.transform.rotation = Quaternion.Euler(0, 0, 45);
        //plane.transform.rotation = Quaternion.SetFromToRotation(departure.transform.localPosition, destination.transform.localPosition);
        //plane.transform.forward = Vector3.MoveTowards(midpoint, earth.transform.position, 0.5f);
        var splinePoints = new List<Vector3>();
        splinePoints.Add(departure.transform.localPosition);
        splinePoints.Add(plane.transform.localPosition);
        splinePoints.Add(destination.transform.localPosition);
        spline = new VectorLine("Spline", new List<Vector3>(segments + 1), 10.0f, LineType.Continuous); //LineType.Discrete
        spline.SetColor(new Color(204, 0, 82));
        spline.MakeSpline(splinePoints.ToArray(), segments, loop);
        //spline.MakeSpline(splinePoints.ToArray());
        //spline.textureScale = 1.0f;
        spline.drawTransform = earth.transform;
        //Debug.Log(transform.position);
        //Debug.Log(spline);
    }
    void LateUpdate()
    {
        spline.Draw3DAuto();
    }
}
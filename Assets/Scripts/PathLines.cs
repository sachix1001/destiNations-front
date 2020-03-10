using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class PathLines : MonoBehaviour
{

	public float orbitSpeed = 0.0f;
	public float rotateSpeed = 10.0f;
	public int orbitLineResolution = 150;
	public Material lineMaterial;   // This should be a material with a shader that will draw on top of the stars

	void Start()
	{
		var orbitLine = new VectorLine("OrbitLine", new List<Vector3>(orbitLineResolution), 2.0f, LineType.Continuous);
		orbitLine.material = lineMaterial;
        //make arc
		orbitLine.MakeCircle(Vector3.zero, Vector3.up, Vector3.Distance(transform.position, Vector3.zero));
		orbitLine.Draw3DAuto();
		Debug.Log("lines lines lines");
	}

	void Update()
	{
		transform.RotateAround(Vector3.zero, Vector3.up, orbitSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
	}
}
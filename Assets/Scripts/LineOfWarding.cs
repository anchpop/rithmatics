using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LineOfWarding : MonoBehaviour {
    public float majorAxis = 1;
    public float minorAxis = 2;
    public int numOfTesselations = 10;

    List<LineRenderer> lines = new List<LineRenderer>();
    
	// Use this for initialization
	void Start () { 
	    for (float i = 0; i < 2 * Mathf.PI; i += 2 * Mathf.PI/numOfTesselations)
        {
            List<Vector3> p = new List<Vector3>();
            p.Add(new Vector3(Mathf.Cos(i) * majorAxis, Mathf.Sin(i) * minorAxis));
            p.Add(new Vector3(Mathf.Cos(i + 2 * Mathf.PI / numOfTesselations) * majorAxis, Mathf.Sin(i + 2 * Mathf.PI / numOfTesselations) * minorAxis));
            addLine(p);
        }
	}

    void addLine(List<Vector3> Points)
    {
        var go = new GameObject();
        go.transform.SetParent(this.transform);

        lines.Add(go.AddComponent<LineRenderer>());
        lines.Last().material = new Material(Shader.Find("Particles/Additive"));
        lines.Last().SetVertexCount(Points.Count);
        lines.Last().SetPositions(Points.ToArray());
        lines.Last().SetColors(Color.white, Color.white);

        lines.Last().SetWidth(.1f, .1f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

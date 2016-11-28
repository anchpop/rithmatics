using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SineRenderer : MonoBehaviour {


    LineRenderer line;
    public float backtrunc = 0;
    public float frontextend = 0;
    
    public float width, amplitude, wavelength, tesselationsPerPeriod, periods;
    public Color color = Color.white;


    // Use this for initialization
    public void Start () {
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetColors(color, color);
        renderLine(0, 0);
    }
    
    public void setParams(float rwidth, float ramplitude, float rwavelength, float rtesselationsPerPeriod, float rperiods, Color rcolor)
    {
        width = rwidth;
        amplitude = ramplitude;
        wavelength = rwavelength;
        tesselationsPerPeriod = rtesselationsPerPeriod;
        periods = rperiods;
        color = rcolor;
    }

    public void setLineColor(Color color)
    {
        line.SetColors(color, color);
    }

    public bool isLineValid()
    {
        return (tesselationsPerPeriod * (periods + frontextend - backtrunc)) > 0;
    }

    public void renderLine(float truncateBeginning, float lengthenEnd)
    {

        line.useWorldSpace = false;
        float lastTessel = (tesselationsPerPeriod * (periods + lengthenEnd - truncateBeginning));
        int numOfTessels = (int)lastTessel;
        if (lastTessel > 0)
        {
            Vector3[] points = new Vector3[numOfTessels + 1];
            for (float x = 0; x < numOfTessels; x++)
            {
                points[(int)x] = getPointHeight(points, x, amplitude, wavelength, tesselationsPerPeriod, truncateBeginning);
            }
            points[numOfTessels] = getPointHeight(points, lastTessel, amplitude, wavelength, tesselationsPerPeriod, truncateBeginning);

            line.SetVertexCount(points.Length);
            line.SetPositions(points);
            line.SetWidth(width, width);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    Vector3 getPointHeight(Vector3[] points, float x, float amplitude, float wavelength, float tesselationsPerPeriod, float truncateBeginning)
    {
        float xpos = ((x / tesselationsPerPeriod) + truncateBeginning) * (2 * Mathf.PI);
        return new Vector3(xpos * wavelength, Mathf.Sin(xpos) * amplitude);
    }
	
    public void increaseBackTruncTo(float amount)
    {
        backtrunc = amount;
        renderLine(amount, frontextend);
    }

    public void increaseFrontExtendTo(float amount)
    {
        frontextend = amount;
        renderLine(backtrunc, amount);
    }


    // Update is called once per frame
    void Update () {
    }
}

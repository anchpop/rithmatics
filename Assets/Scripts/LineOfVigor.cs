using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LineOfVigor : MonoBehaviour {

    public float width = 1;
    public float amplitude = 1;
    public float wavelength = 1;
    public float tesselationsPerPeriod = 30;
    public float periods = 4;

    public float speed = .5f;
    float waveDistanceTraveled;
    

    public Color color = Color.white;

    [HideInInspector]
    public List<SineRenderer> sineWaves = new List<SineRenderer>();

    // Use this for initialization
    public void Start () {
        var initialWave = gameObject.AddComponent<SineRenderer>();
        initialWave.setParams(width, amplitude, wavelength, tesselationsPerPeriod, periods, color);
        sineWaves.Add(initialWave);
	}
	
	// Update is called once per frame
	void Update ()
    {
        waveDistanceTraveled += (Time.deltaTime) * speed;
        if (sineWaves.Count > 0)
        {
            sineWaves.First().increaseBackTruncTo(waveDistanceTraveled);
            sineWaves.Last().increaseFrontExtendTo(waveDistanceTraveled);
        }
        sineWaves = sineWaves.Where(s => s.isLineValid()).ToList();

    }
}

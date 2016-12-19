using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

    List<LineOfVigor> vigours;
    List<LineOfWarding> warders;

    public GameObject lineOfVigor;
    public GameObject lineOfWarding;

	// Use this for initialization
	void Start () {
        Instantiate(lineOfVigor);
        Instantiate(lineOfWarding);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

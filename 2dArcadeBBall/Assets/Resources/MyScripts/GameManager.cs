using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Canvas UI;
    // Start is called before the first frame update
    void Start () {
        UI = GameObject.Find ("UI").GetComponent<Canvas> ();
    }

    // Update is called once per frame
    void Update () {

    }
}
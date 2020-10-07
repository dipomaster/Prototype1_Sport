using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public GameManager GM;
public bool amI_A;
    // Start is called before the first frame update
    void Start()
    {
        GM=GameObject.Find ("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Ball"){
            if(amI_A)
            GM.A=true;
            else
            GM.B=true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DaySchedule : MonoBehaviour {
    public int mHours;
    private GameManager GM;
    // Start is called before the first frame update
    void Start () {
        mHours = 24;
        GM = GameObject.Find ("GM").GetComponent<GameManager> ();
        //if (gameObject.GetComponent<BoxCollider>().isTrigger == false)
        //    GetComponent<BoxCollider>().isTrigger = true;
        //else if (GetComponent<BoxCollider>() == null)
        //   gameObject.AddComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update () {
        GM.UI.GetComponentInChildren<TextMeshProUGUI> ().text = ("Hours left " + mHours);
    }
    void OnTriggerEnter (Collider other) {
        if (other.tag == "Job") {
            mHours -= other.GetComponent<ObjValue> ().mTimeValue;

        }
        // Debug.Log(other.name);

    }
    void OnTriggerExit (Collider other) {

        mHours += other.GetComponent<ObjValue> ().mTimeValue;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyUI : MonoBehaviour {
    public bool mOccupied;
    // Start is called before the first frame update
    void Start () {
        mOccupied = false;
    }

    // Update is called once per frame
    void Update () {
        if (transform.childCount < 1)
            mOccupied = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Job")
    //    {
    //        other.transform.position = transform.position;

    //    }

    //    Debug.Log(other.transform.position);
    //}
}
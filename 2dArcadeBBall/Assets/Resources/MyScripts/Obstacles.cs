using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{ public float tableHeight;
    public Vector3 startPosition;
    public float floatSpeed;
    public float floatAmount;
    public Vector3 endPosition;
    public float length;
    private float startTime;
    public bool direction = true;
    public float  objSpeed;
    // Start is called before the first frame update
    void Start()
    {startTime = Time.time;
        startPosition = gameObject.transform.position;
        tableHeight = transform.position.y;
        endPosition = new Vector3(startPosition.x,startPosition.y,floatAmount);
        length = Vector3.Distance (startPosition, endPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time-startTime) * floatSpeed;
        float fractionOfJourney = distCovered / length;
      transform.position = Vector3.Lerp (startPosition, endPosition, fractionOfJourney);
    }
}

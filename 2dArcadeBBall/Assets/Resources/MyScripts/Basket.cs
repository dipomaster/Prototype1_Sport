
using UnityEngine;

public class Basket : MonoBehaviour {
    public float tableHeight;
    public Vector3 startPosition;
    public float floatSpeed;
    public float floatAmount;
    public Vector3 endPosition;
    public float length;
    private float startTime;
    int index, currentindx;
    public GameObject[] positions;
    public GameObject target;
    public bool direction = true, move = false,combo=false,flying=false;
    // Start is called before the first frame update
    void Start () {
        moveBoard ();
    }

    // Update is called once per frame
    void Update () {
        
        if (move) {
            index = Random.Range (0, 3);
            if(combo){
                index=3;
               
            }
            if (index != currentindx) {
                transform.position = positions[index].transform.position;
                
                moveBoard ();
                if(index==3){
                     transform.rotation=positions[index].transform.rotation;
                }else
                lookAtTarget();
                move = false;
                currentindx = index;
            }
        }else {
            if(flying)
            fly ();
        }
    }

    void fly () {

        float distCovered = (Time.time - startTime) * floatSpeed;
        float fractionOfJourney = distCovered / length;
        if (direction) {
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp (startPosition, endPosition, fractionOfJourney);
            if (transform.position == endPosition) {
                startTime = Time.time;
                direction = false;
            }

        } else if (!direction) {
            transform.position = Vector3.Lerp (endPosition, startPosition, fractionOfJourney);
            if (transform.position == startPosition) {
                startTime = Time.time;
                direction = true;
            }
        }

    }
    void moveBoard () {
        startTime = Time.time;
        startPosition = gameObject.transform.position;
        tableHeight = transform.position.y;
        endPosition = startPosition;
        endPosition += new Vector3 (0, floatAmount, 0);
        length = Vector3.Distance (startPosition, endPosition);
    }

void lookAtTarget(){
    transform.LookAt(target.transform);
}


}
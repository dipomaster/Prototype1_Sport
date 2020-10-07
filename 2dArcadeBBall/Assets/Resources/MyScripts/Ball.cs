
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float timer;
    private float timerStart;
    // Start is called before the first frame update
    void Start()
    {
       timerStart=1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>timerStart+timer){
            Destroy(this.gameObject);
        }
       if(!gameObject.GetComponent<Rigidbody>())
       Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name=="Floor"){
            timerStart=Time.time; 
        }
        
    }
}

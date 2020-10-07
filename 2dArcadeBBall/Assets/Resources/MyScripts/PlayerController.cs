
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update
    public float speed;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private Rigidbody rb;
    public GameObject ball;
    public GameObject L, C, R;
    public List<GameObject> positions;
    public int index = 1;
    public bool canMove;
    private float timestamp;
    public float cooldown;

    void Start () {
        rb = GetComponent<Rigidbody> ();
        positions.Add (L);
        positions.Add (C);
        positions.Add (R);
    }

    // Update is called once per frame
    void Update () {

        //PlayerMovement();
        PlayerMovement2 ();

    }

    void PlayerMovement () {

        //if(Input.GetKey(KeyCode.D))
        //transform.Translate(new Vector3(1*0.1f*speed,0,0));
        if (Input.GetAxis ("Horizontal") > 0) {
            transform.Translate (new Vector3 (1 * 0.1f * speed, 0, 0));
        }
        if (Input.GetAxis ("Horizontal") < 0) {
            transform.Translate (new Vector3 (-1 * 0.1f * speed, 0, 0));
        }
        if (Input.GetAxis ("Vertical") > 0) {
            transform.Translate (new Vector3 (0, 0, 1 * 0.1f * speed));
        }
        if (Input.GetAxis ("Vertical") < 0) {
            transform.Translate (new Vector3 (0, 0, -1 * 0.1f * speed));
        }
        Jump ();

    }

    void PlayerMovement2 () {
        if (canMove) {
            if (Input.GetAxis ("Horizontal") > 0) {
                if (index < positions.Count - 1) {
                    index++;
                    transform.position = (positions[index].transform.position);

                   // Debug.Log (positions[index].name);
                    canMove = false;
                }
            }
            if (Input.GetAxis ("Horizontal") < 0) {
                if (index > 0) {
                    index--;
                    transform.position = (positions[index].transform.position);
                    //Debug.Log (positions[index].name);
                    canMove = false;
                }
            }
            /*if(Input.GetAxis("Vertical")>0){
            transform.Translate(new Vector3(0,0,1*0.1f*speed));
            }
            if(Input.GetAxis("Vertical")<0){
            transform.Translate(new Vector3(0,0,-1*0.1f*speed));
            }
            */

            Jump ();
            timestamp = Time.time;
        }
        if (Time.time > timestamp + cooldown) {
            canMove = true;
        }

    }

    void Jump () {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0) {// && !Input.GetButton ("Jump")
            //transform.Translate(new Vector3(0,0.1f*speed,0));
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //rb.MovePosition(new Vector3(0,0.1f*speed,0));
        }

        transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X"), 0) * Time.deltaTime * 100f);
        //if (Input.GetButton ("Jump")) {
            //rb.MovePosition (transform.position + new Vector3 (0, 0.2f * speed*Time.unscaledDeltaTime, 0));

        //}
//rb.velocity = ((transform.up - transform.position) * Time.deltaTime * speed);


    }
private void OnCollisionEnter(Collision other) {
    if(other.gameObject.name=="Floor"){
        rb.AddForce(transform.up*speed,ForceMode.Impulse);
    }
}
   
}
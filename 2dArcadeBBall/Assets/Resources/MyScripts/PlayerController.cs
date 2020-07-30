using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update
    public float speed;
    public float fallMultiplier=2.5f;
    public float lowJumpMultiplier=2f;
    private Rigidbody rb;
    public GameObject ball;
    void Start () {
rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {

PlayerMovement();

    }

    void PlayerMovement(){

//if(Input.GetKey(KeyCode.D))
//transform.Translate(new Vector3(1*0.1f*speed,0,0));
if(Input.GetAxis("Horizontal")>0){
transform.Translate(new Vector3(1*0.1f*speed,0,0));
}
if(Input.GetAxis("Horizontal")<0){
transform.Translate(new Vector3(-1*0.1f*speed,0,0));
}
if(Input.GetAxis("Vertical")>0){
transform.Translate(new Vector3(0,0,1*0.1f*speed));
}
if(Input.GetAxis("Vertical")<0){
transform.Translate(new Vector3(0,0,-1*0.1f*speed));
}
if(rb.velocity.y<0){
    rb.velocity+=Vector3.up*Physics.gravity.y*(fallMultiplier-1)*Time.deltaTime;
}else if(rb.velocity.y>0 && !Input.GetButton ("Jump")){
//transform.Translate(new Vector3(0,0.1f*speed,0));
rb.velocity+=Vector3.up*Physics.gravity.y*(lowJumpMultiplier-1)*Time.deltaTime;
//rb.MovePosition(new Vector3(0,0.1f*speed,0));
}

transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"),0 ) * Time.deltaTime * 100f);
if(Input.GetButton ("Jump")){
    rb.MovePosition(transform.position+ new Vector3(0,0.2f*speed,0));
}





    }

    
}
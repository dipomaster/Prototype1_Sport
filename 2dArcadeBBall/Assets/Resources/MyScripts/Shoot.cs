using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int power=1;
    public bool canShoot;
    public int powerMax=10;
    public GameObject ball;
    private float timestamp;
    public float cooldown;
    public float pwrmltpl;
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Shoott();


    }

void Shoott(){   
if(canShoot)
if(Input.GetKeyUp("mouse 0")||power==powerMax){
//Debug.Log("shoot");
if(go==null){
     go= Instantiate(ball,transform.position,Quaternion.identity);
     
}
go.AddComponent<Rigidbody>();
go.GetComponent<Rigidbody>().AddForce((transform.forward+transform.up)*power*5*pwrmltpl);
go=null;
power=0;
canShoot=false;
timestamp=Time.time;
}
if(Time.time>timestamp+cooldown){
    canShoot=true;
}
}
private void FixedUpdate() {

   if(power<powerMax){      
    ButtonDown();
    ButtonHeld();

   }
}
void ButtonHeld(){
if(Input.GetKey("mouse 0")&&canShoot){     
    power++;
}

}
void ButtonDown(){
    if(Input.GetKeyDown("mouse 0")&&canShoot)
    {
        go= Instantiate(ball,transform.position,Quaternion.identity);
    }
}

}


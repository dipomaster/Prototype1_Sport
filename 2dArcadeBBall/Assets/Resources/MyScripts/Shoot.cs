
using UnityEngine;

public class Shoot : MonoBehaviour {
    public float power = 1, pwrScale;
    public bool canShoot;
    public float powerMax = 10;
    public GameObject ball, target, targetC;

    private float timestamp;
    public float cooldown;
    public float pwrmltpl, angle;
    private GameObject go;
    // Start is called before the first frame update
    void Start () {

    }
    // Update is called once per frame
    void Update () {
        Shoott ();
        lookAtTarget ();
        
        //Time.timeScale+=(1f/2)*Time.unscaledDeltaTime;
      //  Time.timeScale=Mathf.Clamp(Time.timeScale,0,1);
    }

    void Shoott () {
        if (canShoot)
            if (Input.GetKeyUp ("mouse 0") || power >= powerMax) {
                //Debug.Log("shoot");
                if (go == null) {
                    go = Instantiate (ball, transform.position, Quaternion.identity);

                }
                
                Vector3 targetDir = target.transform.position - transform.position;
                Vector3 latoC = targetC.transform.position - transform.position;
                angle = Vector3.Angle (targetDir, latoC);
                //Debug.Log (angle);
                
               // Debug.Log (Mathf.Tan (angle*Mathf.Deg2Rad));
                go.AddComponent<Rigidbody> ();
                go.GetComponent<Rigidbody> ().AddForce ((transform.forward + (transform.up * Mathf.Tan ((angle)*Mathf.Deg2Rad))) * power * 5 * pwrmltpl);
                go = null;
                power = 0;
                canShoot = false;
                timestamp = Time.time;
                Time.timeScale=1f;
                //Time.fixedDeltaTime=Time.unscaledDeltaTime;
                
            }
        if (Time.time > timestamp + cooldown) {
            canShoot = true;
        }
    }
    private void FixedUpdate () {

        if (power < powerMax) {
            ButtonDown ();
            ButtonHeld ();

        }
    }
    void ButtonHeld () {
        if (Input.GetKey ("mouse 0") && canShoot) {
            
           slowMo();
           power += pwrScale*2;
        }

    }
    void ButtonDown () {
        if (Input.GetKeyDown ("mouse 0") && canShoot) {
            go = Instantiate (ball, transform.position, Quaternion.identity);
        }
    }

    void lookAtTarget () {
        transform.LookAt (target.transform);
    }

    private void OnDrawGizmos () {
        Gizmos.DrawLine (target.transform.position, transform.position);
        Gizmos.DrawLine (targetC.transform.position, transform.position);
    }

     void slowMo(){
        Time.timeScale=0.5f;
         Time.fixedDeltaTime = Time.timeScale * .02f;
 Time.maximumDeltaTime = Time.timeScale * .15f;
    }
}
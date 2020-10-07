
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public Canvas UI;
    public int count;
    public Basket basket;

    public bool A,B,movingBasket;
    public ParticleSystem particle; 
    public GameObject PC;
    // Start is called before the first frame update
    void Start () {
       // UI = GameObject.Find ("UI").GetComponent<Canvas> ();
        particle=GameObject.Find("Score").GetComponent<ParticleSystem>();
        basket=GameObject.Find("basket").GetComponent<Basket>();
        PC=GameObject.Find("PC");
        A=false;
B=A;
particle.Stop();
    }

    // Update is called once per frame
    void Update () {
if(A&&B){
particle.Play();
A=false;
B=A;
count++;
//if(PC.GetComponentInChildren<Shoot>().canShoot
// if(count==3){

//    basket.combo=true;
// }
if(movingBasket)
basket.move=true;

UI.GetComponentInChildren<TextMeshProUGUI>().text=count.ToString();
}
    }


    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    //atributos de la carta
    public Sprite imagen; //parte ed atrás. 
    public Sprite anverso;
    public int tipo;

    public GameObject myGameManager;
    public GameManagerScript myGameManagerScript;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = imagen;
        myGameManager = GameObject.FindGameObjectWithTag("GameController");
        myGameManagerScript = myGameManager.GetComponent<GameManagerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
       // DeshabilitarBoxCollider();
    }

    private void OnMouseDown()
    {

        if (GetComponent<SpriteRenderer>().sprite.Equals(imagen))
        {
            GetComponent<SpriteRenderer>().sprite = anverso;
            myGameManagerScript.ClicOnCard(gameObject);
        }
        else { }
    }

    //public void DeshabilitarBoxCollider()
    //{
    //    if (myGameManagerScript.dobles.Count==2)
    //    {
    //        GetComponent<BoxCollider2D>().enabled = false;
    //    }
    //    else if(myGameManagerScript.dobles.Count < 2)
    //    {
    //        GetComponent<BoxCollider2D>().enabled = true;
    //    }
    //}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    public Sprite imagen;
    public Sprite anverso;

    public GameObject myGameManager;
    public GameManagerScript myGameManagerScript;

    public int tipo;

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
    }

    private void OnMouseDown()
    {
        myGameManagerScript.ClicOnCard(tipo);

//        Debug.Log("He hecho clic en la carta "+name);

        if (GetComponent<SpriteRenderer>().sprite.Equals(imagen))
        {
            GetComponent<SpriteRenderer>().sprite = anverso;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = imagen;
        }
    }
}

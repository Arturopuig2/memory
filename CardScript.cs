using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    public Sprite imagen;
    //public Vector3 posicion;
    //public Vector3 rotacion;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = imagen;
        //posicion = transform.position;
        //Debug.Log(posicion);
        //posicion = new Vector3(-6,1,0);
        //transform.Translate(posicion2);
        //rotacion = new Vector3(0, 0, 90)*Time.deltaTime;
        //transform.Rotate(rotacion);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    Debug.Log("Pressed primary button.");
    }

    private void OnMouseDown()
    {
        Debug.Log("He hecho clic en la carta "+name);
    }
}

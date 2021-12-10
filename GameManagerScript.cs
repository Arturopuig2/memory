using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject MyPrefab;

    int[] tipos = {7,1,0,9,6};
  

    public List<GameObject> ListaCartas = new List<GameObject>();
    public int filas = 2;
    public int columnas = 5;
    public int columnasAsignadas = 0;
    public int filasAsignadas = 0;
    int[] contador = { 0, 0, 0, 0, 0 };


    //LISTA PARA METER LAS IMAGENES DE ANVERSO
    public List<Sprite> Anversos = new List<Sprite>();


    public void ColocarCartas()
    {
        float posX = -6;
        float posY = 3.2f;

        for (int i = 0; i < filas * columnas; i++)
        {
            GameObject nueva_carta = Instantiate(MyPrefab, new Vector3(posX,posY, 0), Quaternion.identity);
            nueva_carta.name = "Carta" + i;


            //ASIGNAR ANVERSOS
            bool encontrado = false;
            int pos = 0;

            while (!encontrado)
            {
                pos = UnityEngine.Random.Range(0, 5);
                if (contador[pos] < 2)
                {
                    contador[pos] += 1;
                    encontrado = true;
                }
            }


            nueva_carta.GetComponent<CardScript>().anverso = Anversos[pos];
            nueva_carta.GetComponent<CardScript>().tipo = tipos[pos];


            ListaCartas.Add(nueva_carta);
            posX += 3;
            columnasAsignadas+=1;



            if (columnasAsignadas == columnas)
            {
                posX = -6;
                posY = posY-3.2f;
                columnasAsignadas = 0;
                filasAsignadas += 1;
            }
        }
    }


    public void ClicOnCard(int tipo)
    {
        Debug.Log("He hecho clic on card de valor "+tipo);
    }


    // Start is called before the first frame update
    void Start()
    {
        ColocarCartas();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
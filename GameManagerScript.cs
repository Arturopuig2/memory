using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject MyPrefab;

    public int filas = 2;
    public int columnas = 5;
    public int columnasAsignadas = 0;
    public int filasAsignadas = 0;
    public int numParejas = 0;

    public GameObject texto;
    public GameObject textoFinal;
    public GameObject botonJugar;

    //ARRAY PARA GUARDAR EL NÚMERO DE CARTAS
    int[] contador = { 0, 0, 0, 0, 0 };

    //ARRAY CON LOS VALORES DE LAS CARTAS
    int[] tipos = { 7, 1, 0, 9, 6 };

    //LISTA PARA METER TODAS LAS CARTAS
    public List<GameObject> ListaCartas = new List<GameObject>();

    //LISTA PARA METER LAS IMAGENES DE ANVERSO
    public List<Sprite> Anversos = new List<Sprite>();

    //LISTA PARA METER LAS CARTAS VOLTEADAS
    public List<GameObject> dobles = new List<GameObject>() { };


    //MÉTOD PARA COLOCAR LAS CARTAS
    public void ColocarCartas()
    {
        float posX = -6;
        float posY = 3.2f;

        for (int i = 0; i < filas * columnas; i++)
        {
            GameObject nueva_carta = Instantiate(MyPrefab, new Vector3(posX,posY, 0), Quaternion.identity);
            nueva_carta.name = "Carta " + i;


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

    //MÉTOD PARA CUANDO HACES CLIC EN UNA CARTA
    public void ClicOnCard(GameObject CardScript)
    {
        Debug.Log("He hecho clic en carta de valor "+ CardScript.GetComponent<CardScript>().tipo);

        dobles.Add(CardScript);


        if (dobles.Count==2)
        {
            DeshabilitarBoxCollider();
            StartCoroutine(WaitAndPrint());
        }
        else { };
    }

    //METOD PARA DESHABILITAR LOS BOXCOLLIDERS DE LAS CARTAS (Y NO PODER CLICAR NINGUNA).
    public void DeshabilitarBoxCollider()
    {
        for (int i = 0; i < ListaCartas.Count; i++)
        {
            ListaCartas[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //METOD PARA HABILITAR LOS BOXCOLLIDERS DE LAS CARTAS (Y PODER CLICARLAS).
    public void HabilitarBoxCollider()
    {
        for (int i = 0; i < ListaCartas.Count; i++)
        {
            ListaCartas[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }


    //METOD PARA COMPROBAR PAREJAS
    public void ComprobarParejas()
    {
        if (dobles[0].GetComponent<CardScript>().tipo.Equals(dobles[1].GetComponent<CardScript>().tipo))
            {
            Debug.Log("PAREJA");
            numParejas ++;
            texto.GetComponent<Text>().text = "NÚMERO DE PAREJAS: " + numParejas;
            dobles[0].SetActive(false);
            dobles[1].SetActive(false);
        }
        else {
            dobles[0].GetComponent<SpriteRenderer>().sprite = MyPrefab.GetComponent<SpriteRenderer>().sprite;
            dobles[1].GetComponent<SpriteRenderer>().sprite = MyPrefab.GetComponent<SpriteRenderer>().sprite;
        };

        dobles.Clear();

        HabilitarBoxCollider();

        if (numParejas.Equals(5))
            {
                textoFinal.GetComponent<Text>().text = "GAME OVER";
                botonJugar.SetActive(true);
            }
    }

    //METOD PARA LA PAUSA ENTRE DOS CARTAS VOLTEADAS
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1F);
        ComprobarParejas();
    }

    //METOD PARA BOTÓN JUGAR
    public void Jugar()
    {
        for (int i = 0; i < 10; i++)
        {
            Destroy(ListaCartas[i]);
        };

        ListaCartas.Clear();

        for (int i = 0; i < 5; i++)
        {
            contador[i] = 0;
        }
        ColocarCartas();
        numParejas = 0;
        textoFinal.GetComponent<Text>().text = "";

        botonJugar.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        botonJugar.SetActive(false);
        ColocarCartas();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
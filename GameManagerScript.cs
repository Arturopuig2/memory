using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject MyPrefab;

    public List<GameObject> ListaCartas = new List<GameObject>();
    public int filas = 2;
    public int columnas = 5;
    public int columnasAsignadas = 0;
    public int filasAsignadas = 0;

    public void ColocarCartas()
    {
        float posX = -6;
        float posY = 3.2f;

        for (int i = 0; i < filas * columnas; i++)
        {
            GameObject nueva_carta = Instantiate(MyPrefab, new Vector3(posX,posY, 0), Quaternion.identity);
            nueva_carta.name = "Carta" + i;
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
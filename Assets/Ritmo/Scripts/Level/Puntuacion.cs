using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI texto;

    public float puntos;

    //Im�genes para indicar c�mo de bien se ha pulsado la �ltima nota (se programar� en una siguiente versi�n)
    public Image perfect;

    public Image good;

    public Image meh;

    public Image bad;

    public void Start()//incializa a 0 el puntaje del nivel
    {
        texto.text = "Puntos: 0";
        PlayerPrefs.SetFloat("Puntos", 0);
        puntos = 0;
    }

    public void SumarPuntuacion(float puntosNuevos)//permite sumar y restar puntos al puntaje actual del nivel
    {
        puntos += puntosNuevos;
        texto.text = "Puntos: " + puntos.ToString();
    }

    //Para mostrarlo en siguiente escena del juego, resultados del nivel
    public void GuardarPuntuacionFinal()
    {
        PlayerPrefs.SetFloat("Puntos", puntos);
    }
}
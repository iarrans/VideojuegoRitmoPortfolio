using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{

    public TextMeshProUGUI textoTiempo; //texto cuenta atrás

    public float tiempoTranscurrido;//cuenta progresiva para evaluar si deben spawnear las notas
    public float tiempoRestante; //inicialmente, valdrá el tiempo que dure la canción
    public float delay;

    public void Start()
    {

        int minutos = Mathf.Max(Mathf.FloorToInt(tiempoRestante / 60), 0);     //Extraemos los minutos
        int segundos = Mathf.Max(Mathf.FloorToInt(tiempoRestante % 60), 0);    //Extraemos los segundos
        if (segundos >= 10) textoTiempo.text = minutos + ":" + segundos;                    //Si los segundos son mayores o iguales que 10, concatenamos y construimos el texto
        else textoTiempo.text = minutos + ":" + "0" + segundos;

    }

    public void Update()
    {
        tiempoRestante -= Time.deltaTime; //para saber cuánto tiempo queda de la canción
        tiempoTranscurrido += Time.deltaTime; //para llevar la cuenta de la canción, para poder spawnear la nota a tiempo

        //parseo del tiempo a formato contador
        int minutos = Mathf.Max(Mathf.FloorToInt(tiempoRestante / 60), 0);     //Extraemos los minutos
        int segundos = Mathf.Max(Mathf.FloorToInt(tiempoRestante % 60), 0);    //Extraemos los segundos
        if (segundos >= 10) textoTiempo.text = minutos + ":" + segundos;                    //Si los segundos son mayores o iguales que 10, concatenamos y construimos el texto
        else textoTiempo.text = minutos + ":" + "0" + segundos;                             //Si los segundos son menors que 10, añadimos un 0 a nuestros segundos, concatenamos

        if (tiempoRestante <= 0 - delay -2) //Cuando acaba la canción, se considera que el nivel ha terminado.
        {
            textoTiempo.text = "Fin";
            FinNivel();
        }
    }

    private void FinNivel()//Prepara los datos para cambiar de nivel
    {
        GameObject.Find("Puntuacion").GetComponent<Puntuacion>().GuardarPuntuacionFinal();
        GameObject.Find("Combo").GetComponent<Combo>().GuardarMaxCombo();
        SceneManager.LoadScene("LevelResults");
    }
}

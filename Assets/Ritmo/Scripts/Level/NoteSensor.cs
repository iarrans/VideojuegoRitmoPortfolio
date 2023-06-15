using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSensor : MonoBehaviour
{
    public bool keyPressed = false;

    //Controlan el comportamiento del sensor para poder puntuar
    public KeyCode sensorKey;
    public GameObject noteSensor;//sensor asociado al raíl
    public GameObject noteSpawner;//spawner asociado al raíl
   
    public float spawnDelay; //tiempo que tarda una nota, desde que spwanea hasta distancia 0 del sensor 

    //Atributos utilizados para determinar la puntuación y el combo
    public GameObject combo;
    public GameObject puntuacion;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(sensorKey)) {//controles para activar si se pulsó bien la nota y cambiar el color para feedback visual
            keyPressed = true;
            noteSensor.GetComponent<Image>().color = new Color(0.5f, 0, 0);
            CheckDistance();
        }

        if (Input.GetKeyUp(sensorKey))
        {
            keyPressed = false;
            noteSensor.GetComponent<Image>().color = new Color(1, 0, 0);
        }
    }

    public void CheckDistance()
    {  
        if (noteSpawner.transform.childCount > 0) { //comprobamos que tiene hijos
            GameObject primeraNota = noteSpawner.transform.GetChild(0).gameObject; //obtenemos el primero de sus hijos
            float distanciaNotaSensor = Vector2.Distance(primeraNota.transform.position, noteSensor.transform.position); //distancia de la nota al sensor
            if (distanciaNotaSensor < 100)
            {
                string calificacion = NoteEvaluation(distanciaNotaSensor);
                //Debug.Log("La distancia es " + distanciaNotaSensor + " " + calificacion);
                Destroy(primeraNota);
            }
            else
            {
                puntuacion.GetComponent<Puntuacion>().SumarPuntuacion(-1);
                combo.GetComponent<Combo>().BreakCombo();
            }         
        }        
    }

    public string NoteEvaluation(float distancia)//se calcula la puntuación obtenida por la nota, teniendo en cuenta los combos
    {
        string valor = "";
        float puntos = 0;
        bool acierto = true;
        if (distancia < 30)
        {
            valor = "perfecto";
            puntos = 3;

        } else if (distancia > 30 && distancia < 50)
        {
            valor = "bien";
            puntos = 2;
        }
        else if (distancia > 50 && distancia < 70)
        {
            valor = "regular";
            puntos = 1;
        }
        else
        {
            valor = "mal";
            puntos = -1;
            acierto = false;
            combo.GetComponent<Combo>().BreakCombo();
        }
        if (acierto) {
            combo.GetComponent<Combo>().SumarCombo(1);
        }
        int comboMultiplier = combo.GetComponent<Combo>().ComboMultiplier();
        puntuacion.GetComponent<Puntuacion>().SumarPuntuacion(puntos * comboMultiplier);
        return valor;
    }


}

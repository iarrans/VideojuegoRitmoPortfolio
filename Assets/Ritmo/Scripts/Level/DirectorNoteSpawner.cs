using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class DirectorNoteSpawner : MonoBehaviour
{
    public List<GameObject> railes; //el orden de los spawners será de izquierda a derecha. En el editor asignado

    public float songSpeed; //velocidad a la que bajarán las notas. En el editor

    public Temporizador temporizador; //comprueba el tiempo de la canción por el que vamos

    public float timeDelay;//tiempo que tarda nota desde que spawnea hasta que aparece. Se calcula solo

    public TextAsset notesFile;

    [HideInInspector]
    public List<string> lineasFichero;//lineas del fichero, en formato string

    [HideInInspector]
    public List<float> segundoNotas;//tiempos en los que se debe spawnear una nueva nota
    [HideInInspector]
    public List<int> railesNotas;//carril por el que se spawneará
    [HideInInspector]
    public bool areNotesLoaded = false; //para poder indicar en qué frame ya están cargadas las notas


    private void Start()
    {
        CalculaDelay();
        LoadNotes(notesFile);
        temporizador.delay = timeDelay;
    }

    public void Update()
    {
        if (areNotesLoaded && segundoNotas.Count > 0)
        {
            CheckSpawning();
        }
    }

    public void CalculaDelay()//Cálculo de la diferencia de tiempo entre que la nota spawnea y pasa realmente por el sensor.
    {
        GameObject railW = railes[0];//escogemos el primer raíl, ya que todos los del nivel son instancias del mismo prefab. Las operaciones serían idénticas.
        GameObject sensor = railW.transform.GetChild(1).gameObject;//el sensor y el spawner de notas son hijos del prefab raíl.
        GameObject spawner = railW.transform.GetChild(2).gameObject; //Con sus gameobjects, podremos obtener sus posiciones.
        float distanciaSpawnSensor = Vector2.Distance(spawner.transform.position, sensor.transform.position); //distancia de la nota al sensor
        timeDelay = distanciaSpawnSensor / songSpeed;

    }

    private void CheckSpawning()//primero spawning sin delay
    {
        if (temporizador.tiempoTranscurrido >= segundoNotas[0])
        {
            SpawnNote(railes[railesNotas[0] -1]);
            segundoNotas.RemoveAt(0); //si el tiempo real transcurrido de la canción es mayor que el de la marca de la nota, se spawnea y se elimina de la lista
            railesNotas.RemoveAt(0); //para evaluar la siguiente nota en el siguiente frame.
        }
    }

    public void SpawnNote(GameObject rail)
    {
        NoteSpawner spawnrail = rail.GetComponent<NoteSpawner>();//dado un raíl, spawneamos una nota desde su spawner
        spawnrail.noteSpeed = songSpeed;
        spawnrail.SpawnNote();
    }

    public void LoadNotes(TextAsset noteSheet)
    {
        //Preparamos la lectura del archivo

        string[] noteSpawns = noteSheet.text.Split(new char[] { '\n' });//separamos las líneas del fichero en un array

        foreach (string note in noteSpawns)
        {
            if (!note.StartsWith("//"))
            {
                string[] lineadividida = note.Split(",");//dividimos el string de la línea del fichero por el separador, las comas, en marca del segundo y carril por el que spawnear
                this.lineasFichero.Add(note);
                segundoNotas.Add(float.Parse(lineadividida[0], CultureInfo.InvariantCulture));//cultureinfo es para que parsee siempre los decimales por el punto, independientemente del idioma
                railesNotas.Add(int.Parse(lineadividida[1]));
            }

        }

        areNotesLoaded = true;//para que se ejecute el método checkspawning

    }


}

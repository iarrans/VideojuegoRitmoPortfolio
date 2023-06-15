using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class NoteLevelRecorder : MonoBehaviour
{
    //Script hecho para escribir las notas de los niveles en las marcas de tiempo que se va pulsando.

    //Para leer las líneas del fichero
    public string notesPath; //path al txt donde están las notas. Se debe indicar en el editor.

    public DirectorNoteSpawner directorNote;

    public Temporizador temporizador;

    public float tiempoRealCancion = 0;

    public KeyCode teclaW;
    public KeyCode teclaA;
    public KeyCode teclaS;
    public KeyCode teclaD;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempoRealCancion = temporizador.tiempoTranscurrido - directorNote.timeDelay;


        if (Input.GetKeyDown(teclaW))
        {
            RecordNote(tiempoRealCancion, 1);
        }

        if (Input.GetKeyDown(teclaA))
        {
            RecordNote(tiempoRealCancion, 2);
        }

        if (Input.GetKeyDown(teclaS))
        {
            RecordNote(tiempoRealCancion, 3);
        }

        if (Input.GetKeyDown(teclaD))
        {
            RecordNote(tiempoRealCancion, 4);
        }
    }

    public void RecordNote(float timeStamp, float rail)
    {
        //Preparamos la lectura del archivo
        StreamWriter sw = new StreamWriter(notesPath,true); // creamos reader en la ubicación del nivel


        string timeFormatted = timeStamp.ToString().Replace(",",".");
        //Write a line of text
        sw.WriteLine(timeFormatted + "," + rail.ToString());
        //Write a second line of text
        //Close the file
        sw.Close();

    }
}

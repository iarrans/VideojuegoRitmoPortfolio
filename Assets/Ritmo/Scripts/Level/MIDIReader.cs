using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MIDIReader : MonoBehaviour
{

    public static MidiFile midiFile;

    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestrictionA; //La
    //public InstrumentNameEvent instrumentoFiltro;

    public List<double> segundosNotas = new List<double>();//lista de los tiempos, en segundos, donde aparecen notas en el midi

    public string path; //path del fichero en el que escribiremos el nivel resultante

    public string txtPath; //path del fichero MIDI del que queremos leer la melodía. Se entiende que este fichero tan solo lo compone la "voz" que seguirá el nivel.

    //Creador de txt en formato de los niveles del juego a partir de un MIDI
    void Start()
    {
        midiFile = MidiFile.Read(path); //leemos el MIDI con DryWetMidi
        StreamWriter sw = new StreamWriter(txtPath, true); // creamos reader para poder escribir el nivel en txt

        foreach (var note in midiFile.GetNotes())
            {
            
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, midiFile.GetTempoMap());
                double second = (double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f;//obtenemos el tempo de la canción para obtener los segundos
                segundosNotas.Add(second);
                string timeFormatted = second.ToString().Replace(",", ".");//parseo para que no de problemas con la lectura del segundo. En los sistemas en español, suele ser un problema.
                sw.WriteLine(timeFormatted + "," + Random.Range(1, 4).ToString() + "," + note.NoteNumber); //Actualmente, los raíles de las notas del nivel, se generan automáticamente para crearlo más ágil.    
            }
        Debug.Log("Cantidad de notas grabadas en el txt: " + segundosNotas.Count);//Si todo funciona bien, en la consola del editor veremos la cantidad de notas del nivel
        sw.Close();
    }


}

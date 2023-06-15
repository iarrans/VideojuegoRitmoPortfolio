using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource cancionNivel;//Tiene asociado el reproductor de la canción  del nivel

    public DirectorNoteSpawner directorSpawners;

    public bool isPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        this.cancionNivel.playOnAwake = false; //para que se respete el tiempo de Delay
        directorSpawners.temporizador.tiempoRestante = cancionNivel.clip.length;//Asigna la duración del nivel de acuerdo con la duración de la canción
    }

    // Update is called once per frame
    void Update()
    {
        if (directorSpawners.temporizador.tiempoTranscurrido >= directorSpawners.timeDelay && !isPlaying)//espera a que transcurra el tiempo de delay para comenzar a reproducir la canción
        {
            cancionNivel.Play();
            isPlaying = true;//pasamos el booleano a true para que no se comience de nuevo la reproducción.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    public GameObject note;

    public GameObject noteSpawner;

    public float noteSpeed;


    // Start is called before the first frame update
    void Start()
    {
        noteSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnNote();
        }
    }

    public void SpawnNote()
    {
        GameObject notaNueva  = Instantiate(note, noteSpawner.transform.position, Quaternion.identity, noteSpawner.transform);
        notaNueva.GetComponent<NoteBehaviour>().speed = noteSpeed;
    }
}

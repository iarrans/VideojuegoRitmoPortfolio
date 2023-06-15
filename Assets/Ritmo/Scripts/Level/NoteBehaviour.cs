using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBehaviour : MonoBehaviour
{
    public GameObject note;

    public float speed; //velocidad a la que caerá la nota

    public KeyCode noteKey;

    void Start()
    {
        
    }
    
    void Update()
    {

        note.transform.position += Vector3.down * speed * Time.deltaTime; //Baja la nota según la velocidad y el tiempo real entre fotogramas

        if (note.transform.position.y <= 40)//y global, no del canvas
        {
            note.name = "impossible";
            note.GetComponent<Image>().color = new Color(1, 1, 0);
            note.transform.SetAsLastSibling();//si la nota es imposible ya de tocar, pasa a ser el último hermano para dejar de evaluarse y sin eliminarse
        }

        if (note.transform.position.y <= 5)//y global, no del canvas
        {
            FailedNote();
        }
    }

    void FailedNote() //si se falla la nota (baja más allá de los sensores) se destruye
    {
        Destroy(note);
        GameObject.Find("Puntuacion").GetComponent<Puntuacion>().SumarPuntuacion(-1);
        GameObject.Find("Combo").GetComponent<Combo>().BreakCombo();
    }


    

}

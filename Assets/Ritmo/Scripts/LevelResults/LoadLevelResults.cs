using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadLevelResults : MonoBehaviour
{

    // Textos de combo mostrados en la UI
    public TextMeshProUGUI textoPuntos;
    //texto que indica el  multiplicador del combo cuando es distinto a 1
    public TextMeshProUGUI textoCombo;


    // Start is called before the first frame update
    void Start()
    {
        textoPuntos.text = PlayerPrefs.GetFloat("Puntos").ToString();
        textoCombo.text = PlayerPrefs.GetInt("MaxCombo").ToString();
    }

}

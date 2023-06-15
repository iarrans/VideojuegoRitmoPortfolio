using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{

    // Textos de combo mostrados en la UI
    public TextMeshProUGUI texto;
    //texto que indica el  multiplicador del combo cuando es distinto a 1
    public TextMeshProUGUI textoMultiplier;


    public int comboActual;

    public List<int> combosRealizados;

    public int comboMultiply;

    public void Start()//al inicio del nivel, no existen combos y el multiplicador, por defecto, se asignar� a uno al evaluar la siguiente nota.
    {
        PlayerPrefs.SetInt("MaxCombo", 0);
        texto.text = "";
        textoMultiplier.text = "";
        comboActual = 0;
    }

    public void SumarCombo(int puntosNuevos)//funci�n que suma al combo la cantidad pasada por par�metro. tambi�n actualiza el texto.
    {
        comboActual += puntosNuevos;
        texto.text = "Combo: " + comboActual.ToString();
    }

    public void BreakCombo()//Al romperse un combo, el texto de combo y el del multiplicador se "desactivan" y el combo vuelve a cero
    {
        combosRealizados.Add(comboActual);
        comboActual = 0;
        texto.text = "";
        textoMultiplier.text = "";
        comboMultiply = 1;
    }


    //�Seg�n c�mo de alto est� el combo, se multiplicar�n los puntos obtenidos por cada una de las notas.
    //Tambi�n se "activar�" el texto que indica el combo si el multiplicador es distinto de uno.
    public int ComboMultiplier()
    {
        if (comboActual > 100)
        {
            comboMultiply = 4;
            textoMultiplier.text = "x4";
        } else if (comboActual > 50)
        {
            comboMultiply = 3;
            textoMultiplier.text = "x3";
        }
        else if (comboActual > 25)
        {
            comboMultiply = 2;
            textoMultiplier.text = "x2";
        }
        else
        {
            comboMultiply = 1;
            textoMultiplier.text = ""; //"Desactivamos" el texto de combos
        }

        return comboMultiply;

    }

    internal void GuardarMaxCombo() //guarda el m�ximo de los combos producidos para mostrarlo en la siguiente escena 
    {
        combosRealizados.Sort();
        int tamanio = combosRealizados.Count;
        PlayerPrefs.SetInt("MaxCombo", combosRealizados[tamanio -1]); //necesario para poder pasar el dato a la siguiente escena f�cilmente
    }
}

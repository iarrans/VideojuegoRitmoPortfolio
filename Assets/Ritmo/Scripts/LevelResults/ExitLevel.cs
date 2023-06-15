using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenForm()
    {
        Application.OpenURL("https://isabel-arrans.itch.io/");
    }
}

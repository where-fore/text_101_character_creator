using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }
}

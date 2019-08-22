using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject escapeMenuParent = null;

    private void Start()
    {
        escapeMenuParent.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escapeMenuParent.SetActive(!escapeMenuParent.activeSelf);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject escapeMenuParent = null;
    private Animator escapeMenuParentAnimator = null;
    private string escapeMenuExitAnimationTriggerStringReference = "Exit Menu";

    private void Start()
    {
        escapeMenuParent.SetActive(false);
        escapeMenuParentAnimator = escapeMenuParent.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (escapeMenuParent.activeSelf == false)
            {
                OpenEscapeMenu();
            }
            else if (escapeMenuParent.activeSelf == true)
            {
                CloseEscapeMenu();
            }
        }
    }

    private void OpenEscapeMenu()
    {
        escapeMenuParent.SetActive(true);
    }

    private void CloseEscapeMenu()
    {
        escapeMenuParentAnimator.SetTrigger(escapeMenuExitAnimationTriggerStringReference);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application.Quit() function called.");
    }
}

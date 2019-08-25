using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainUICanvasParent = null;
    [SerializeField] private GameObject escapeMenuParent = null;
    private Animator escapeMenuParentAnimator = null;
    private string escapeMenuExitAnimationTriggerStringReference = "Exit Menu";
    [Tooltip("Make sure the blackout has your desired animation")]
    [SerializeField] private GameObject blackout = null;

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

    public void FadeToBlack()
    {
        GameObject blackoutObject = Instantiate(blackout);
        blackoutObject.transform.SetParent(mainUICanvasParent.transform);
        blackoutObject.transform.localScale = new Vector3(1, 1, 1);
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application.Quit() function called.");
    }
}

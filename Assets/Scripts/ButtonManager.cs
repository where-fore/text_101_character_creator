using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] allOptionButtons = null;

    public void DisableOptionButtons()
    {
        foreach (Button button in allOptionButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void EnableOptionButtons()
    {
        foreach (Button button in allOptionButtons)
        {
            button.gameObject.SetActive(true);
        }
    }
}

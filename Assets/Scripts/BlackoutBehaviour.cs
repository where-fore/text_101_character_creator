using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackoutBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject myText = null;

    private void Start()
    {
        myText.SetActive(false);
    }

    public void ShowText()
    {
        Debug.Log("ShowText() called.");
        myText.SetActive(true);
    }
}

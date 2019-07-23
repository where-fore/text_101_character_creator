using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slide : MonoBehaviour
{
    private string bodyText = "";
    public void SetBodyText(string newBodyText) {bodyText = newBodyText;}

    private TextMeshProUGUI myTextComponent= null;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        myTextComponent.text = bodyText;
    }
}

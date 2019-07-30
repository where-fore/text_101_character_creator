using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameLoop gameLoopManager = null;
    [SerializeField] private TextMeshProUGUI bodyText = null;
    [SerializeField] private TextMeshProUGUI option1Text = null;
    [SerializeField] private TextMeshProUGUI option2Text = null;
    [SerializeField] private TextMeshProUGUI option3Text = null;
    //private TextMeshProUGUI[] allFields = null;
    private Dictionary<TextMeshProUGUI, string> allFields = new Dictionary<TextMeshProUGUI, string>();
    
    public void UpdateText()
    {

        QuestionSlide currentQuestion = gameLoopManager.getCurrentQuestion();

        string newBodyText = currentQuestion.GetBodyText();
        allFields.Add(bodyText, newBodyText);

        string newOption1Text = currentQuestion.GetOption1Text();
        allFields.Add(option1Text, newOption1Text);
        
        string newOption2Text = currentQuestion.GetOption2Text();
        allFields.Add(option2Text, newOption2Text);
        
        string newOption3Text = currentQuestion.GetOption3Text();
        allFields.Add(option3Text, newOption3Text);
        
        foreach (KeyValuePair<TextMeshProUGUI, string> update in allFields)
        {
            UpdateFieldText(update.Key, update.Value);
        }

        allFields.Clear();


    }

    private void UpdateFieldText(TextMeshProUGUI field, string newText)
    {
        if (newText != field.text)
        {
            field.text = newText;
            Debug.Log("Updated " + field.name);
        }
    }
}

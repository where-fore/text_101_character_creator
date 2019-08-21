using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameLoop gameLoopManager = null;
    [SerializeField] private GameObject classTextParent = null;
    [SerializeField] private TextMeshProUGUI classTitleText = null;
    [SerializeField] private TextMeshProUGUI classBodyText = null;
    [SerializeField] private GameObject optionTextParent = null;
    [SerializeField] private TextMeshProUGUI optionBodyText = null;
    [SerializeField] private TextMeshProUGUI option1Text = null;
    [SerializeField] private TextMeshProUGUI option2Text = null;
    [SerializeField] private TextMeshProUGUI option3Text = null;
    //private TextMeshProUGUI[] allFields = null;
    private Dictionary<TextMeshProUGUI, string> allFields = new Dictionary<TextMeshProUGUI, string>();
    
    public void UpdateQuestionText()
    {

        QuestionSlide currentQuestion = gameLoopManager.getCurrentQuestion();

        string newBodyText = currentQuestion.GetBodyText();
        allFields.Add(optionBodyText, newBodyText);

        string newOption1Text = currentQuestion.GetOptionText(1);
        allFields.Add(option1Text, newOption1Text);
        
        string newOption2Text = currentQuestion.GetOptionText(2);
        allFields.Add(option2Text, newOption2Text);
        
        string newOption3Text = currentQuestion.GetOptionText(3);
        allFields.Add(option3Text, newOption3Text);
        
        foreach (KeyValuePair<TextMeshProUGUI, string> update in allFields)
        {
            UpdateFieldText(update.Key, update.Value);
        }

        allFields.Clear();


    }

    public void ShowClassText(ClassSlide classSlide)
    {     
        optionTextParent.SetActive(false);
        UpdateFieldText(classTitleText, classSlide.GetClassTitle());
        UpdateFieldText(classBodyText, classSlide.GetBodyText());
        classTextParent.SetActive(true);
    }

    private void UpdateFieldText(TextMeshProUGUI field, string newText)
    {
        if (newText != field.text)
        {
            field.text = newText;
            //Debug.Log("Updated " + field.name);
        }
    }
}

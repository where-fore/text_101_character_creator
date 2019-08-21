using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private QuestionSlide[] questions = null;
    [SerializeField] private TextManager textManager = null;
    private int currentQuestionArrayIndex = 0;
    private QuestionSlide currentQuestion = null;
    public QuestionSlide getCurrentQuestion() {return currentQuestion;}
    [SerializeField] private ConsequenceTracker consequenceTracker = null;

    [SerializeField] private GameObject warriorIndicator = null;

    [SerializeField] private GameObject  mageIndicator = null;

    [SerializeField] private GameObject thiefIndicator = null;


    void Start()
    {
        warriorIndicator.SetActive(false);
        mageIndicator.SetActive(false);
        thiefIndicator.SetActive(false);


        currentQuestionArrayIndex = 0;
        UpdateCurrentQuestion();
    }


    public void ChooseOption(int optionNumber)
    {
        int consequence = GetConsequenceForOption(optionNumber);

        consequenceTracker.RememberConsequence(consequence);
        
        StartCoroutine(ActivateIndicator(consequence));

        NextQuestion();
    }


    private void NextQuestion()
    {
        if (currentQuestionArrayIndex + 1 == questions.Length)
        {
            EndCharacterCreation();
        }
        else
        {
            currentQuestionArrayIndex ++;
            UpdateCurrentQuestion();
        }
    }


    private void UpdateCurrentQuestion()
    {
        currentQuestion = questions[currentQuestionArrayIndex];
        textManager.UpdateQuestionText();
    }


    private void EndCharacterCreation()
    {
        ClassSlide chosenClass = consequenceTracker.DetermineClass();
        Debug.Log("Your class is: " + chosenClass.GetClassTitle());
    }


    private IEnumerator ActivateIndicator(int consequenceNumber)
    {
        GameObject indicator = null;

        if (consequenceNumber == Globals.warrior)
        {
            indicator = warriorIndicator;
        }
        if (consequenceNumber == Globals.mage)
        {
            indicator = mageIndicator;
        }
        if (consequenceNumber == Globals.thief)
        {
            indicator = thiefIndicator;
        }

        indicator.SetActive(true);
        yield return new WaitForSeconds(2f);
        indicator.SetActive(false);
    }


    private int GetConsequenceForOption(int optionNumber)
    {
        if (optionNumber > 3 || optionNumber < 1)
        {
            throw new UnityException("Option Text Request out of range: *" + optionNumber + "* is not 1, 2 or 3.");
        }

        int consequence = currentQuestion.GetConsequence(optionNumber);

        if (consequence == Globals.warrior)
        {
            return Globals.warrior;
        }
        if (consequence == Globals.mage)
        {
            return Globals.mage;
        }
        if (consequence == Globals.thief)
        {
            return Globals.thief;
        }
        throw new UnityException("End of loop that shouldn't come to an to end.");
    }

}

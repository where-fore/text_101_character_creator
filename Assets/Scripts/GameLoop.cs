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

    void Update()
    {

    }

    public void ChooseFirstOption()
    {
        StartCoroutine(ActivateIndicator(OptionConsequence(1)));
        NextQuestion();
    }

    public void ChooseSecondOption()
    {
        StartCoroutine(ActivateIndicator(OptionConsequence(2)));
        NextQuestion();
    }
    public void ChooseThirdOption()
    {
        StartCoroutine(ActivateIndicator(OptionConsequence(3)));
        NextQuestion();
    }

    private void NextQuestion()
    {
        currentQuestionArrayIndex ++;
        UpdateCurrentQuestion();
    }

    private void UpdateCurrentQuestion()
    {
        currentQuestion = questions[currentQuestionArrayIndex];
        textManager.UpdateText();
    }

    private IEnumerator ActivateIndicator(GameObject indicator)
    {
        indicator.SetActive(true);
        yield return new WaitForSeconds(2f);
        indicator.SetActive(false);
    }

    private GameObject OptionConsequence(int optionNumber)
    {
        if (optionNumber == 1)
        {
            if (currentQuestion.GetOption1Consequence() == Globals.warrior)
            {
                return warriorIndicator;
            }
            else if (currentQuestion.GetOption1Consequence() == Globals.mage)
            {
                return mageIndicator;
            }
            else if (currentQuestion.GetOption1Consequence() == Globals.thief)
            {
                return thiefIndicator;
            }
        }
        else if (optionNumber == 2)
        {
            if (currentQuestion.GetOption2Consequence() == Globals.warrior)
            {
                return warriorIndicator;
            }
            else if (currentQuestion.GetOption2Consequence() == Globals.mage)
            {
                return mageIndicator;
            }
            else if (currentQuestion.GetOption2Consequence() == Globals.thief)
            {
                return thiefIndicator;
            }
        }
        else if (optionNumber == 3)
        {
            if (currentQuestion.GetOption3Consequence() == Globals.warrior)
            {
                return warriorIndicator;
            }
            else if (currentQuestion.GetOption3Consequence() == Globals.mage)
            {
                return mageIndicator;
            }
            else if (currentQuestion.GetOption3Consequence() == Globals.thief)
            {
                return thiefIndicator;
            }
        }
        throw new UnityException("CheckConsequence Failure");
    }

}

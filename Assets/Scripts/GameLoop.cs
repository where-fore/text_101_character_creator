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
        StartCoroutine(ActivateIndicator(GetIndicatorForConsequence(1)));
        NextQuestion();
    }

    public void ChooseSecondOption()
    {
        StartCoroutine(ActivateIndicator(GetIndicatorForConsequence(2)));
        NextQuestion();
    }
    public void ChooseThirdOption()
    {
        StartCoroutine(ActivateIndicator(GetIndicatorForConsequence(3)));
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

    private GameObject GetIndicatorForConsequence(int optionNumber)
    {
        if (optionNumber > 3 || optionNumber < 1)
        {
            throw new UnityException("Option Text Request out of range: *" + optionNumber + "* is not 1, 2 or 3.");
        }

        int consequence = currentQuestion.GetConsequence(optionNumber);

        if (consequence == Globals.warrior)
        {
            return warriorIndicator;
        }
        if (consequence == Globals.mage)
        {
            return mageIndicator;
        }
        if (consequence == Globals.thief)
        {
            return thiefIndicator;
        }
        throw new UnityException("End of loop that shouldn't be able to end.");
    }

}

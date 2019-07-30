using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class OldGameLoop : MonoBehaviour
{
    [SerializeField]
    GameObject gameReactionManagerObject = null;

    GameReactions gameReactionManager = null;

    [SerializeField]
    State startingState = null;

    [SerializeField]
    State endingState = null;

    [SerializeField]
    GameObject bodyText = null;

    TextMeshProUGUI bodyTextComponent = null;
    
    TextScroll bodyTextScrollScript = null;


    [SerializeField]
    GameObject titleText = null;

    TextMeshProUGUI titleTextComponent = null;
    
    TextScroll titleTextScrollScript = null;

    string title = "Character Creator";

    // If the title text is ever == to exitConfirmation, then pressing escape will immediately close the game.
    string exitConfirmation = "Press escape to exit";


    [SerializeField]
    GameObject optionsText = null;

    TextMeshProUGUI optionsTextComponent = null;

    TextScroll optionsTextScrollScript = null;


    public State state;

    public string currentStateID = null;

    void Start()
    {
        gameReactionManager = gameReactionManagerObject.GetComponent<GameReactions>();

        bodyTextComponent = bodyText.GetComponent<TextMeshProUGUI>();
        bodyTextScrollScript = bodyText.GetComponent<TextScroll>();

        titleTextComponent = titleText.GetComponent<TextMeshProUGUI>();
        titleTextScrollScript = titleText.GetComponent<TextScroll>();

        optionsTextComponent = optionsText.GetComponent<TextMeshProUGUI>();
        optionsTextScrollScript = optionsText.GetComponent<TextScroll>();

        state = startingState;
        UpdateText();       
    
    }

    void Update()
    {
        currentStateID = state.stateID;
        ManageInputs();
    }

    void ManageInputs()
    {
        int numberOfOptions = state.GetStateOptions().Length;

        // Move to state according to key press
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (numberOfOptions >= 1 && bodyTextScrollScript.finished && optionsTextScrollScript.finished)
            {
                ChooseOption1();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (numberOfOptions >= 2 && bodyTextScrollScript.finished && optionsTextScrollScript.finished)
            {
                ChooseOption2();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
             if (numberOfOptions >= 3 && bodyTextScrollScript.finished && optionsTextScrollScript.finished)
            {
                ChooseOption3();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
             if (numberOfOptions >= 4 && bodyTextScrollScript.finished && optionsTextScrollScript.finished)
            {
                ChooseOption4();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
             if (numberOfOptions >= 5 && bodyTextScrollScript.finished && optionsTextScrollScript.finished)
            {
                ChooseOption5();
            }
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!bodyTextScrollScript.finished && !optionsTextScrollScript.finished)
            {
                bodyTextScrollScript.SkipText();
                optionsTextScrollScript.SkipText();

            }

            if (titleTextComponent.text == exitConfirmation)
            {
                Exit();
            }
            else
            {
                titleTextComponent.text = exitConfirmation;
                titleTextScrollScript.SkipText();
            }


        }

    }

    void Exit()
    {
        // Remove me for builds, add me for editing
        // EditorApplication.isPlaying = false;

        // Add me for builds, remove me for editing
        Application.Quit();
    }
    
    void UpdateText()
    {
        if (state != endingState)
        {
            bodyTextComponent.text = state.GetStateText();
            titleTextComponent.text = title;
        }
        else
        {
            bodyTextComponent.text = gameReactionManager.StatsText();
            titleTextComponent.text = exitConfirmation;
        }

        string allOptions = "";
        foreach (string option in state.GetStateOptions())
        {
            allOptions = allOptions + option + "\n";
        }

        optionsTextComponent.text = allOptions;

        bodyTextScrollScript.ScrollNewText();
        optionsTextScrollScript.ScrollNewText();
    }

    void NextState()
    {
        State[] nextStates = state.GetNextStates();
        state = nextStates[0];
    }
    
    void ChooseOption1()
    {
        gameReactionManager.Option1();

        NextState();
        UpdateText();
    }

    void ChooseOption2()
    {
        gameReactionManager.Option2();

        NextState();
        UpdateText();
    }

    void ChooseOption3()
    {
        gameReactionManager.Option3();

        NextState();
        UpdateText();
    }

    void ChooseOption4()
    {
        gameReactionManager.Option4();

        NextState();
        UpdateText();
    }

    void ChooseOption5()
    {
        gameReactionManager.Option5();

        NextState();
        UpdateText();
    }
}

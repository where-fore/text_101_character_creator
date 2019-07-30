using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question Slide")]
public class QuestionSlide : ScriptableObject
{
    [Tooltip("The slide that will come after this one")] [SerializeField]
    private QuestionSlide nextSlide = null;

    [Tooltip("The main text that will appear in the centre of the screen")]
    [TextArea(8,12)] [SerializeField]
    private string bodyText = "";


    [Header("First Option")] [Space(25f)]
    [TextArea(1,4)] [SerializeField]
    private string option1Text = "";
    
    [Tooltip("1 for Warrior, 2 for Mage, 3 for Thief")] [SerializeField] [Range(1f, 3f)]
    private int consequence1 = 0;


    [Header("Second Option")] [Space(25f)]
    [TextArea(1,4)] [SerializeField]
    private string option2Text = "";

    [Tooltip("1 for Warrior, 2 for Mage, 3 for Thief")] [SerializeField] [Range(1f, 3f)]
    private int consequence2 = 0;


    [Header("Third Option")] [Space(25f)]
    [TextArea(1,4)] [SerializeField]
    private string option3Text = "";

    [Tooltip("1 for Warrior, 2 for Mage, 3 for Thief")] [SerializeField] [Range(1f, 3f)]
    private int consequence3 = 0;

    [TextArea(15,15)] [SerializeField] [Space(60f)]
    private string notes = "";

//
//  Here be methods
//

    public string GetBodyText() {return bodyText;}
    public string GetOption1Text() {return option1Text;}
    public string GetOption2Text() {return option2Text;}
    public string GetOption3Text() {return option3Text;}
    public int GetOption1Consequence() {return consequence1;}
    public int GetOption2Consequence() {return consequence2;}
    public int GetOption3Consequence() {return consequence3;}
    public QuestionSlide GetNextSlide() {return nextSlide;}
    private void GetRidOfUnityWarning() {string variableToFix = notes;} //removes the Unity warning that this variable is declared, but never used

}
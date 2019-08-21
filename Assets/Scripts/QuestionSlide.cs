using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question Slide")]
public class QuestionSlide : ScriptableObject
{
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
    public string GetOptionText(int number)
    {
        if (number > 3 || number < 1)
        {
            throw new UnityException("Option Text Request out of range: *" + number + "* is not 1, 2 or 3.");
        }

        if (number == 1)
        {
            return option1Text;
        }
        if (number == 2)
        {
            return option2Text;
        }
        if (number == 3)
        {
            return option3Text;
        }
        throw new UnityException("End of loop that shouldn't be able to end.");
    }
    public int GetConsequence(int number)
    {
        if (number > 3 || number < 1)
        {
            throw new UnityException("Option Text Request out of range: *" + number + "* is not 1, 2 or 3.");
        }

        if (number == 1)
        {
            return consequence1;
        }
        if (number == 2)
        {
            return consequence2;
        }
        if (number == 3)
        {
            return consequence3;
        }
        throw new UnityException("End of loop that shouldn't be able to end.");
    }
    private void GetRidOfUnityWarning() {var variableToFix = notes;} //removes the Unity warning that this variable is declared, but never used

}
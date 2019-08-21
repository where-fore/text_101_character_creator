using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Class Slide")]
public class ClassSlide : ScriptableObject
{
    [Tooltip("Title Text")]
    [TextArea(1, 2)] [SerializeField]
    private string titleText = "";
    public string GetClassTitle() {return titleText;}

    [Tooltip("Body Text")]
    [TextArea(4, 18)] [SerializeField]
    private string bodyText = "";
    public string GetBodyText() {return bodyText;}

    [Tooltip("Image to display")]
    [SerializeField] [Space(25f)]
    private Sprite classImage = null;

    [Tooltip("The range is inclusive. eg. min 3 and max 5 -> a value of 3, 4, or 5 passes.")]
    [SerializeField] [Space(25f)] 
    private int minWarriorChoices = 0;
    [SerializeField]
    private int maxWarriorChoices = 0;

    [Tooltip("The range is inclusive. eg. min 3 & max 5 -> a value of 3, 4, or 5 passes.")]
    [SerializeField] [Space(25f)] 
    private int minMageChoices = 0;
    [SerializeField]
    private int maxMageChoices = 0;

    [Tooltip("The range is inclusive. eg. min 3 and max 5 -> a value of 3, 4, or 5 passes.")]
    [SerializeField] [Space(25f)]
    private int minThiefChoices = 0;
    [SerializeField]
    private int maxThiefChoices = 0;


    [Tooltip("Notes for developers")]
    [TextArea(15,15)] [SerializeField] [Space(60f)]
    private string notes = "";

    public bool CheckIfFitsClass(int warriorChoices, int mageChoices, int thiefChoices)
    {
        bool passedWarriorCheck = isWithin(warriorChoices, minWarriorChoices, maxWarriorChoices);
        bool passedMageCheck = isWithin(mageChoices, minMageChoices, maxMageChoices);
        bool passedThiefCheck = isWithin(thiefChoices, minThiefChoices, maxThiefChoices);
        
        if (passedWarriorCheck && passedMageCheck && passedThiefCheck)
        {
            return true;
        }
        else return false;
    }

    private bool isWithin(int subject, int min, int max) // ex: is 5 in my range? isWithin(5, 3, 5) -> True! 5 is within the boundaries of 3 and 5.
    {
        return (subject >= min && subject <= max);
    }

    private void GetRidOfUnityWarning() {var variableToFix = notes;} //removes the Unity warning that this variable is declared, but never used
}

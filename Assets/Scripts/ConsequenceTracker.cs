using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsequenceTracker : MonoBehaviour
{
    private int warriorChoices = 0;
    private int mageChoices = 0;
    private int thiefChoices = 0;

    [Tooltip("Will loop through the classes in this order, checking each one for a fit. Put catch-all classes at the bottom/end of this list, and more specific choices near the top.")]
    [SerializeField] private ClassSlide[] availableClasses = null;

    public void RememberConsequence(int classInt)
    {
        if (classInt == Globals.warrior)
        {
            warriorChoices ++;
        }
        if (classInt == Globals.mage)
        {
            mageChoices ++;
        }
        if (classInt == Globals.thief)
        {
            thiefChoices ++;
        }
    }

    public ClassSlide DetermineClass()
    {
        foreach (ClassSlide characterClass in availableClasses)
        {
            if (characterClass.CheckIfFitsClass(warriorChoices, mageChoices, thiefChoices))
            {
                return characterClass;
            }
        }
        throw new UnityException("End of loop that shouldn't be able to end.");
    }
}

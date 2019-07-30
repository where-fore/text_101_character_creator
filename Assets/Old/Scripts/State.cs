using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{    
    [SerializeField]
    public string stateID = null;
    
    [TextArea(10,14)] [SerializeField]
    string text = "";

    [TextArea(1, 4)] [SerializeField]
    string[] options = null;

    [SerializeField]
    State[] nextStates = null;


    [SerializeField]
    int[] option1 = null;

    [SerializeField]
    int[] option2 = null;

    [SerializeField]
    int[] option3 = null;
    
    [SerializeField]
    int[] option4 = null;

    [SerializeField]
    int[] option5 = null;

    [TextArea(30,20)] [SerializeField]
    string notes = "";


    public string GetStateText()
    {
        return text;
    }

    public string[] GetStateOptions()
    {
        return options;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public int[] GetStateStats1()
    {
        return option1;
    }

    public int[] GetStateStats2()
    {
        return option2;
    }

    public int[] GetStateStats3()
    {
        return option3;
    }

    public int[] GetStateStats4()
    {
        return option4;
    }

    public int[] GetStateStats5()
    {
        return option5;
    }

    void GetRidOfUnityWarning()
    {
        // without this method, unity will throw a warning for the serialized string "notes" never getting used
        string useless = notes;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReactions : MonoBehaviour
{
    [SerializeField]
    GameObject gameLoopManagerObject = null;

    OldGameLoop gameLoopManager = null;

    List<int> stats = null;

    void Start()
    {
        InitializeStats();

        gameLoopManager = gameLoopManagerObject.GetComponent<OldGameLoop>();
    }

    void InitializeStats()
    {
        stats = new List<int>
        {
            7,
            8,
            8,
            8,
            7,
            7,
        };
    }

    public string StatsText()
    {
        string text = "";

        text = text + "Strength: " + stats[0] + "\n";
        text = text + "Dexterity: " + stats[1] + "\n";
        text = text + "Consitution: " + stats[2] + "\n";
        text = text + "Intelligence: " + stats[3] + "\n";
        text = text + "Wisdom: " + stats[4] + "\n";
        text = text + "Charisma: " + stats[5] + "\n";

        text = text + "\nThanks for playing!\nYou can press escape to close the game.";

        return text;
    }

    public void Option1()
    {
        int count = 0;
        while (count <= 5)
        {
            stats[count] = stats[count] + gameLoopManager.state.GetStateStats1()[count];
            count ++;
        }
    }

    public void Option2()
    {
        int count = 0;
        while (count <= 5)
        {
            stats[count] = stats[count] + gameLoopManager.state.GetStateStats2()[count];
            count ++;
        }
        
    }

    public void Option3()
    {
        int count = 0;
        while (count <= 5)
        {
            stats[count] = stats[count] + gameLoopManager.state.GetStateStats3()[count];
            count ++;
        }
    }

    public void Option4()
    {
        int count = 0;
        while (count <= 5)
        {
            stats[count] = stats[count] + gameLoopManager.state.GetStateStats4()[count];
            count ++;
        }
    }

    public void Option5()
    {
        int count = 0;
        while (count <= 5)
        {
            stats[count] = stats[count] + gameLoopManager.state.GetStateStats5()[count];
            count ++;
        }
    }
}

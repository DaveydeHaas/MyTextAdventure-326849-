using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAdventure : MonoBehaviour
{
    private enum States
    {
        start,
        Intro,
        R1Question1,
        R1_F,
        R1_R,
        R1_L,
    }


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnUserInput(string input)
    {
        if (input == "start")
        {
            startintro();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("*Type START to begin...*");
        }
    }
    void ShowMainMenu()
    {
        Terminal.WriteLine("Welcome by Burning House");
        Terminal.WriteLine("");
        Terminal.WriteLine("this game is a Text Adventure");
        Terminal.WriteLine("That means you have to make choices");
        Terminal.WriteLine("");
        Terminal.WriteLine("*Type START to begin...*");
    }

    void startintro()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("test");
    }
}

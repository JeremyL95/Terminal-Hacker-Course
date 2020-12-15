using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        print(input == "1"); //boolean

       if (input == "menu")
        {
            ShowMainMenu();
        }
       
       else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level" + " " + level);
        Terminal.WriteLine("Please enter you password:");
    }
}

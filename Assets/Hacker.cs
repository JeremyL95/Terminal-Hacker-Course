using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "book", "librarian", "rack", "borrow", "counter" };
    string[] level2Passwords = { "rifle", "gun", "station", "arrest", "prison" };
    string[] level3Passwords = { "astronaunt", "science", "programming", "rocket", "proffesional" };

    //Game State
    int level;   
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

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
       if (input == "menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
       else if (input == "exit" || input == "close" || input == "quit")
        {
            Application.Quit();
        }    
       else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
       else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter you password, hint:" + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Opps, Try Again");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You got a book....");
                //printing an ASCII art as a reward
                Terminal.WriteLine(@"
                    ___________
                   /         //
                  /         //
                 /________ //
                (_________(/
                "
                );
                break;
            case 2:
                Terminal.WriteLine("You got a prison key....");
                //printing an ASCII art as a reward
                Terminal.WriteLine(@"
                ___
               /0  \_______ 
               \___/-=' =  '
               "
                );
                break;
            case 3:
                Terminal.WriteLine("You are an astronaunt ....");
                //printing an ASCII art as a reward
                Terminal.WriteLine(@"
                _ __   __ _ ___  __ _
               | '_ \ / _' / __|/ _' |
               | | | | (_| \__ \ (_| |
               |_| |_|\__,_|___)\__,_|
               "
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}

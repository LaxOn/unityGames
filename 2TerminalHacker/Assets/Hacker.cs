using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "diesel", "cheating", "pollution", "emissions", "epa", };
    string[] level2Passwords = { "bankrupt", "special purpose entity", "fraud", "talking points", "litigation" };
    string[] level3Passwords = { "russians", "cambridge analytica", "we run ads", "presidential election", "respectfully senator" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Volkswagen!");
        Terminal.WriteLine("Press 2 for Enron");
        Terminal.WriteLine("Press 3 for Facebook");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input) {
        if (input == "menu") { // we can always go direct to main menu
            ShowMainMenu();
        } else if (input =="quit" || input == "close" || input == "exit") {
            Terminal.ClearScreen();
            Terminal.WriteLine("If on the web, close the tab");
            Application.Quit();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber) {
            level = int.Parse(input);
            AskForPassword();
        } else if (input == "666") // easter egg
          {
            Terminal.WriteLine("You've summoned a demon!");

        } else {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password: ");
        Terminal.WriteLine("Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword() {
        switch (level) {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayWinScreen();
        } else {
            AskForPassword();
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward() {
        switch (level) {
            case 1:
                Terminal.WriteLine("You looted a defective car!");
                Terminal.WriteLine(@"
             ______--------___
             /|             / |
  o___________|_\__________/__|
 ]|___     |  |=   ||  =|___  |""
//   \\    |  |____||_///   \\|""
| X |\--------------/| X |\""
 \___ /             \___ /
");
                break;
            case 2:
                Terminal.WriteLine("You stole a pile of dirty money!");
                Terminal.WriteLine(@"
  _....._
  ';-.--';'
    }===={      
  .'  _|_ '.    
  /:: (_|_` \    
 |::  ,_|_)  \  
 \::.   |    /
  '::_______/
"
                );
                break;
            case 3:
                Terminal.WriteLine("You digitally extracted The DNA!");
                Terminal.WriteLine(@"
.--'""`'--._    _.--'""`'--._    _.-
  '-:`.' |`| ""':-.  '-:`.'|`|""':-.
'.  '.  | |  | | '.  '.  | |  | | '. 
: '.  '.| |  | | '.  '.| |  | | '.  '
'   '.  `.:_ | :_.' '.  `.:_ | :_.' '
       `-..,..- '       `-..,..-'       
"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
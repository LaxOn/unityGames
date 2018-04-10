using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game State
    enum Company {
        Facebook,
        Enron,
        Volkswagen
    }

    enum Screen {
        MainMenu,
        PickCompany,
        PickLevel,
        Password,
        Win
    }

    //string name;
    //name = "hi";
    int level;
    string[] level1Passwords = { "" };
    string[] level2Passwords = { "" };
    string[] level3Passwords = { "" };
    string password;
    Company currentCompany;
    Screen currentScreen;

    // Use this for initialization
    void Start() {
        ShowMainMenu();
    }




    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu();
        } else if (currentScreen == Screen.PickCompany) {
            RunPickCompany(input);
        } else if (currentScreen == Screen.PickLevel) {
            RunPickLevel(input);
        } else if (currentScreen == Screen.Password) {
            RunPassword(input);
        } else if (currentScreen == Screen.Win) {
            RunWin();
        }
    }

    void ShowMainMenu() {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Enter your selection:");
        Terminal.WriteLine("Facebook, Enron, or Volkswagen?");
        currentScreen = Screen.PickCompany;
    }

    void RunPickCompany(string input) {
        if (input.ToUpper() == "Facebook".ToUpper()) {
            currentCompany = Company.Facebook;
            Terminal.WriteLine("Please select a level, Zuckerberg!");
            currentScreen = Screen.PickLevel;
        } else if (input.ToUpper() == "Enron".ToUpper()) {
            currentCompany = Company.Enron;
            Terminal.WriteLine("Please select a level, you filthy CEO!");
            currentScreen = Screen.PickLevel;
        } else if (input.ToUpper() == "Volkswagen".ToUpper()) {
            currentCompany = Company.Volkswagen;
            Terminal.WriteLine("Please select a level!, you cheater!");
            currentScreen = Screen.PickLevel;
        } else {
            Terminal.ClearScreen();
            Terminal.WriteLine("Please choose a valid company!");
            Terminal.WriteLine("Facebook, Enron, or Volkswagen?\n");
        }
    }

    private void RunPickLevel(string input) {
        Terminal.ClearScreen();
        if (input == "1") {
            level = int.Parse(input);
            if (currentCompany == Company.Enron) password = "Enron1";
            else if (currentCompany == Company.Facebook) password = "Facebook1";
            else if (currentCompany == Company.Volkswagen) password = "Volkswagen1";
            Terminal.WriteLine("You have chosen level " + level);
            Terminal.WriteLine("Please enter your password:");
            currentScreen = Screen.Password;
        } else if (input == "2") {
            level = int.Parse(input);
            if (currentCompany == Company.Enron) password = "Enron1";
            else if (currentCompany == Company.Facebook) password = "Facebook1";
            else if (currentCompany == Company.Volkswagen) password = "Volkswagen1";
            Terminal.WriteLine("You have chosen level " + level);
            Terminal.WriteLine("Please enter your password:");
            currentScreen = Screen.Password;
        } else if (input == "3") {
            level = int.Parse(input);
            if (currentCompany == Company.Enron) password = "Enron1";
            else if (currentCompany == Company.Facebook) password = "Facebook1";
            else if (currentCompany == Company.Volkswagen) password = "Volkswagen1";
            Terminal.WriteLine("You have chosen level " + level);
            Terminal.WriteLine("Please enter your password:");
            currentScreen = Screen.Password;
        } else {
            Terminal.WriteLine("Please choose a valid level!");
        }

        //switch (name) {
        //    case "007":
        //        print("");
        //        break;
        //    default:
        //        print("");
        //        break;
        //}
    }



    private void RunPassword(string input) {
        Terminal.ClearScreen();
        if (input == password && level == 3) {
            Terminal.WriteLine("Congratulations! You won the game!");
            Terminal.WriteLine("Now back to real life...");
            currentScreen = Screen.Win;
        } else if (input == password) {
            Terminal.WriteLine("You got it!");
            Terminal.WriteLine("You passed level " + level +"!");
            Terminal.WriteLine("Can you guess the next one?");
            ++level;
        } else {
            Terminal.WriteLine("That's not the password! Ha-ha!");
        }
    }

    private void RunWin() {
       
    }

}

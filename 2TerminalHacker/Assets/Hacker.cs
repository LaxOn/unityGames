using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game State
    int level = 1;

    // Use this for initialization
    void Start () {
        print("Hello Console");
        ShowMainMenu();
    }

    void ShowMainMenu() {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for Facebook");
        Terminal.WriteLine("Press 2 for Enron");
        Terminal.WriteLine("Press 3 for Volkswagen\n");
        Terminal.WriteLine("Enter your selection:");
    }


    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu();
        }
        else if (input == "1") {
            Terminal.WriteLine("Please select a level, Zuckerberg!");
            StartGame();
        } else if (input == "2") {
            Terminal.WriteLine("Please select a level, you filthy CEO!");
        } else if (input == "3") {
            Terminal.WriteLine("Please select a level!, you cheater!");
        }
    }

    void StartGame() {
        Terminal.WriteLine("You have chosen level " + level);
    }
}

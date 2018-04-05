using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Hello Console");
        //Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for Facebook");
        Terminal.WriteLine("Press 1 for Enron");
        Terminal.WriteLine("Press 1 for Volkswagen\n");
        Terminal.WriteLine("Enter your selection:");


    }

    void OnUserInput(string input) {
        Terminal.WriteLine("You typed " + input);
    }
    
}

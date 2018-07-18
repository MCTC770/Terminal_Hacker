using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour

{
	int level;
	private string greeting = "Hello Tom";
	private enum Screen { MainMenu, Password, Win };
	string[] levelNames = { "local library", "police station", "NASA" };
	private string password;
	private string[][] passwordIndex = 
	{
		new string[] { "books", "aisle", "self", "password", "font", "borrow" },
		new string[] { "prisoner", "handcuffs", "holster", "uniform", "arrest" },
		new string[] { "starfield", "telescope", "environment", "exploration", "astronauts" }
	};
	private string passwordSuccess = "Password correct. Login successful!";
	private string passwordFail = "Wrong password. Please try again:";
	Screen currentScreen;

	void Start()
	{
		ShowMainMenu(greeting);
	}

	void ShowMainMenu(string parameter)
	{
		currentScreen = Screen.MainMenu;
		print("Current screen: " + currentScreen);
		Terminal.ClearScreen();
		Terminal.WriteLine(parameter + "\n");
		Terminal.WriteLine(
			"What would you like to hack into?\n\n" +
			"Press 1 for the local library\n" +
			"Press 2 for the police station\n" +
			"Press 3 for NASA\n\n" +
			"Enter your selection:");
	}

	void OnUserInput(string input)
	{
		print("User input: " + input);

		if (input == "menu")
		{
			ShowMainMenu(greeting);
		}
		else if (currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password)
		{
			RunPassword(input);
		}
		else if (currentScreen == Screen.Win)
		{
			RunWin(input);
		}
	}

	void RunMainMenu(string input)
	{
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber)
		{
			level = int.Parse(input);
			StartGame(levelNames[(int.Parse(input) - 1)]);
		}
		else if (input == "007")
		{
			Terminal.WriteLine("Please choose a valid level Mr. Bond");
		}
		else
		{
			Terminal.WriteLine("Please choose a valid level");
		}
	}

	void RunPassword(string input)
	{

		if (input == password)
		{
			DisplayWinScreen();
		}
		else
		{
			Terminal.WriteLine(passwordFail);
		}

	}

	private void DisplayWinScreen()
	{
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	private void ShowLevelReward()
	{
		switch(level)
		{
			case 1:
				Terminal.WriteLine("Have a book...");
				Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"
				);
				break;
			case 2:
				Terminal.WriteLine("Here is your badge...");
				Terminal.WriteLine(@"
   ,   /\   ,
  / '-'  '-' \
 |   POLICE   |
 \    .--.    /
  |  ( 19 )  |
  \   '--'   /
   '--.  .--'
       \/
"
				);
				break;
			case 3:
				Terminal.WriteLine("That's one small step for you,\none giant leap for mankind...");
				Terminal.WriteLine(@"
      .
     .'.
     |o|
    .'o'.
    |.-.|
    '   '
"
				);
				break;
			default:
				Debug.LogError("Invalid level reached");
				break;
		}

	}

	void RunWin(string input)
	{

	}

	private void StartGame (string stage)
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		switch(level)
		{
			case 1:
				password = passwordIndex[0][Random.Range(0, passwordIndex[0].Length)];
				break;
			case 2:
				password = passwordIndex[1][Random.Range(0, passwordIndex[1].Length)];
				break;
			case 3:
				password = passwordIndex[2][Random.Range(0, passwordIndex[2].Length)];
				break;
			default:
				Debug.LogError("Invalid level number");
				break;
		}
		print("current password: " + password);
		Terminal.WriteLine("Trying to enter " + stage + " network");
		Terminal.WriteLine("Please enter your password:");
		print("Loading stage '" + stage + "' (level number " + level + ")");
	}
}

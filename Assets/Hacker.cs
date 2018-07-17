using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour

{
	int level;
	private string greeting = "Hello Tom";
	private enum Screen { MainMenu, Password, Win };
	Screen currentScreen = Screen.MainMenu;

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
		if (input == "1")
		{
			level = 1;
			StartGame("local library");
		}
		else if (input == "2")
		{
			level = 2;
			StartGame("police station");
		}
		else if (input == "3")
		{
			level = 3;
			StartGame("NASA");
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

	}

	void RunWin(string input)
	{

	}

	private void StartGame (string stage)
	{
		currentScreen = Screen.Password;
		Terminal.WriteLine("Trying to enter " + stage + " network");
		Terminal.WriteLine("Please enter your password");
		print("Loading stage '" + stage + "' (level number " + level + ")");
	}
}

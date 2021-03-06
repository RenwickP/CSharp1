using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {

    private GameService _gameService = new GameService();

    private bool playingGame = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      _gameService.firstPrint();
      while (playingGame)
      {

        Print();
        GetUserInput();

      }
    }
    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {

      _gameService.printStatus();
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      //   System.Console.WriteLine("Chose options, (move) forward or backward to move into another room");
      switch (command)
      {

        case "use":
          _gameService.UseItem(option);
          break;

        case "quit":
          playingGame = false;
          break;

        case "move":

          _gameService.Go(option);
          break;

        case "look":
          _gameService.Look();

          break;

        case "get":
          _gameService.Get(option);
          break;

        case "search":
          _gameService.xtraprint(option);
          break;

        case "help":
          _gameService.Help();
          break;

        case "inventory":
          _gameService.Inventory();
          break;

        default:
          System.Console.WriteLine("this is something esle");
          break;

      }

    }


    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (String Message in _gameService.Messages)

      {
        Console.WriteLine(Message.ToString());

      }
      _gameService.Messages.Clear();


    }



  }
}
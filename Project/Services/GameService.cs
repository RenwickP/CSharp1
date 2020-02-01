using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void printStatus()
    {
      System.Console.WriteLine($"Welcome to Room: {_game.CurrentRoom.Name}");
      System.Console.WriteLine($"to {_game.CurrentRoom.Description}");
    }
    public void Go(string direction)

    {
      if (direction == "forward" && _game.CurrentRoom.InnerRoom != null)
      {
        _game.CurrentRoom = _game.CurrentRoom.InnerRoom;

        // Messages.Add($"Welcome to {_game.CurrentRoom.Name}");
        // Messages.Add($"{_game.CurrentRoom.Description}");
      }
      else if (direction == "back" && _game.CurrentRoom.OuterRoom != null)
      {
        _game.CurrentRoom = _game.CurrentRoom.OuterRoom;
        // Messages.Add($"Welcome to {_game.CurrentRoom.Name}");
        // Messages.Add($"to {_game.CurrentRoom.Description}");
      }

      else { Messages.Add("Bad command"); }

    }
    public void Help()
    {
      Messages.Add("Commands are: Help, Move Forward, Move Back, Look, Quit");
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add($"Welcome to {_game.CurrentRoom.Description}");
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      if (itemName != "vroom")
      {
        Messages.Add("You dont have any items. You know you cant do that...");
      }



    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}
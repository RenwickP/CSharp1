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
    public void firstPrint()
    {
      System.Console.WriteLine($"Welcome to Room: {_game.CurrentRoom.Name}");
      System.Console.WriteLine($"{_game.CurrentRoom.Description}");
    }
    public void printStatus()
    {
      // foreach (Item i in _game.CurrentPlayer.Inventory)
      //   if (i.Name == "gem" && _game.CurrentRoom.Name == "Four")
      //   {

      //     _game.CurrentRoom.Description = "The room shimmers and somthing seems differnt. Perhaps this gem is the secret to getting out of here...";
      //   }

      // {
      //   System.Console.WriteLine("The room shimmers and somthing seems differnt. Perhaps this gem is the secret to getting out of here... ");

      // }

    }

    public void xtraprint()
    {

      if (_game.CurrentRoom.Items == null)
      {
        System.Console.WriteLine("no items found");
      }
      else
        foreach (Item i in _game.CurrentRoom.Items)
        {
          Messages.Add($"{i.Name}");
        }
    }
    public void Go(string direction)

    {
      if (direction == "forward" && _game.CurrentRoom.InnerRoom != null)
      {
        _game.CurrentRoom = _game.CurrentRoom.InnerRoom;

        // Messages.Add($"Welcome to {_game.CurrentRoom.Name}");
        Messages.Add($"{_game.CurrentRoom.Description}");

      }


      else if (direction == "back" && _game.CurrentRoom.OuterRoom != null)
      {
        _game.CurrentRoom = _game.CurrentRoom.OuterRoom;
        // Messages.Add($"Welcome to {_game.CurrentRoom.Name}");
        Messages.Add($"{_game.CurrentRoom.Description}");


      }

      else { Messages.Add("There is no where else to go"); }

    }
    public void Help()
    {
      Messages.Add("Commands are: Help, Move Forward, Move Back, Look, Quit, search");
    }
    public void Get()
    {
      if (_game.CurrentRoom.Items == null)
      {
        System.Console.WriteLine("no items");
      }
      else if (_game.CurrentRoom.Items != null)
      {

        ////Why doesnt this work?????????????
        // _game.CurrentRoom.Description = "The room shimmers and somthing seems differnt. Perhaps this gem is the secret to getting out of here...";
        /////!!!!!!!!!!!!!!1////?

        //  foreach (Item i in _game.CurrentRoom.Items)
        //     {
        // _game.CurrentRoom.Items.AddRange(_game.CurrentPlayer.Inventory);
        _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);

        _game.CurrentRoom.Items = null;

        if (_game.CurrentRoom.Name == "Three")
        {

          _game.CurrentRoom.InnerRoom.Description = "The room shimmers and somthing seems differnt. Perhaps this gem is the secret to getting out of here...";
        }



      }
    }
    public void Inventory()
    {


      // System.Console.WriteLine(_game.CurrentPlayer.Inventory);
      foreach (Item i in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{i.Name}");
      }
      // System.Console.WriteLine($"name of hero is... {_game.CurrentPlayer.Name}");
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


      foreach (Item i in _game.CurrentPlayer.Inventory)
      {

        if (i.Name == itemName)
        {

          if (itemName == "gem" && _game.CurrentPlayer.Inventory != null && _game.CurrentRoom.Name == "Four")
          {
            System.Console.WriteLine("You Win!");
          }
          else if (itemName == "gem" && _game.CurrentPlayer.Inventory != null && _game.CurrentRoom.Name != "Four")
            System.Console.WriteLine("You Lose!");

        }
        else
        {
          System.Console.WriteLine("cant do that");
        }
      }
    }
  }
}
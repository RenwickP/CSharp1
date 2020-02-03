using ConsoleAdventure.Project.Interfaces;


namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    // public IItem Item { get; set; }
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }


    //NOTE Make yo rooms here...
    public void Setup()
    {
      Player Hero = new Player("Hero");

      Room One = new Room("One", "You have entered this mysterious place. With no idea how expansive it is or what dangers await you are forced to consider its dimensions, a squre room with one ominus door leading deeper and no way out. The enternace has somehow disapered. Forward is the only way now...");

      Room Two = new Room("Two", "You have made it this far. The room does not disapoint, its wonderful and spooky at the same time.");

      Room Three = new Room("Three", "This is a square room and looks just like all the rest. Perhaps you can find something significant in this one.");

      Room Four = new Room("Four", "Its the last room and time to make all the important choices");

      // Two.Items.Add(new Item("torch", "lights the room"));
      Three.Items.Add(new Item("gem", "Its a magic gem"));
      Item Gem = new Item("gem", "Magic Gem");

      One.InnerRoom = Two;
      Two.OuterRoom = One;
      Two.InnerRoom = Three;
      Three.InnerRoom = Four;
      Three.OuterRoom = Two;
      Four.OuterRoom = Three;




      CurrentRoom = One;
      CurrentPlayer = Hero;
      // CurrentPlayer.Inventory = null;

    }
    public Game()
    {
      Setup();
    }
  }
}
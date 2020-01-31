using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room One = new Room("One", "This is the first room you enter. Its pretty cool but what is the point of anything really? Welcome to your own existential morass. Perhaps exploration will give you meaning...");

      Room Two = new Room("Two", "Oh cool another room...");

      Room Three = new Room("Three", "This is a square room just like all the rest. Perhaps you can find something worth doing in this one.");

      Room Four = new Room("Four", "Its your choice win or die in this room");

      One.InnerRoom = Two;
      Two.OuterRoom = One;
      Two.InnerRoom = Three;
      Three.InnerRoom = Four;
      Three.OuterRoom = Two;
      Four.OuterRoom = Three;


      CurrentRoom = One;

    }
    public Game()
    {
      Setup();
    }
  }
}
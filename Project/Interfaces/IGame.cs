using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IGame
  {
    IRoom CurrentRoom { get; set; }
    IPlayer CurrentPlayer { get; set; }
    // IItem Items { get; set; }
    void Setup();
  }
}
using System;
using ConsoleAdventure.Project;

namespace ConsoleAdventure
{
  public class Program
  {
    public static void Main(string[] args)

    {
      Project.Controllers.GameController gc = new Project.Controllers.GameController();
      gc.Run();


    }
  }
}

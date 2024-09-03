
using Moo;

namespace MooGame
{
    class MainClass
	{

		public static void Main(string[] args)
		{
            Iui iui = new ConsoleUI();
			IO io = new IO(iui);
            Game game = new Game(iui, io);
			game.Run();

		}
	}
}
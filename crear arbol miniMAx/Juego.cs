using System;

namespace juegoIA	
{
	class Juego
	{
		
		public static void Main(string[] args)
		{
			Console.ForegroundColor= ConsoleColor.Red;
			string entrada="m";
					
			while(entrada != "s")
			{
			//Inicializar juego		
			Game game = new Game();
			game.play();
			Console.WriteLine("Ingrese s para salir o n para nueva partida ");
			entrada = Console.ReadLine();
			}
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{

	public class Game
	{
		public static int WIDTH = 12;
		public static int UPPER = 35;
		public static int LOWER = 25;
		
		private Jugador player1 = new ComputerPlayer();
		private Jugador player2 = new HumanPlayer();
		private List<int> naipesHuman = new List<int>();
		private List<int> naipesComputer = new List<int>();
		private int limite;
		private bool juegaHumano = false;
		
		
		public Game()
		{
			var rnd = new Random();
			limite = rnd.Next(LOWER, UPPER);
			
			naipesHuman = Enumerable.Range(1, WIDTH).OrderBy(x => rnd.Next()).Take(WIDTH / 2).ToList();
			
			for (int i = 1; i <= WIDTH; i++)
			{
				if (!naipesHuman.Contains(i))
				{
					naipesComputer.Add(i);
				}
			}
			
			naipesComputer= DesordenarLista(naipesComputer);
			
			player1.inicializar(naipesComputer, naipesHuman, limite);
			player2.inicializar(naipesHuman, naipesComputer, limite);
		}
		
		
		private void printScreen()
		{
			Console.WriteLine();
			Console.WriteLine("Limite:" + limite.ToString());
		}
		
		
		private void turn(Jugador jugador, Jugador oponente, List<int> naipes)
		{
			int carta = jugador.descartarUnaCarta();
			
			if(carta == 0)
			{
				limite=-100;
			}
			else
			{
				Console.WriteLine(carta);
				naipes.Remove(carta);
				limite -= carta;
				oponente.cartaDelOponente(carta);
				juegaHumano = !juegaHumano;
			}
		}
		
		
		private void printWinner()
		{
			if (!juegaHumano) {
				Console.WriteLine("Gano el User");
			} else {
				Console.WriteLine("Gano Computer");
			}
			
		}
		
		
		private bool fin()
		{
			return limite < 0;
		}
		
		
		public void play()
		{
			while (!this.fin())
			{
				this.printScreen();
				this.turn(player2, player1, naipesHuman); // Juega el usuario
				if (!this.fin())
				{
					Console.Clear();
					this.printScreen();
					this.turn(player1, player2, naipesComputer); // Juega la IA
				}
			}
			if(limite == -100)
			{
			}
			else
			{
				this.printWinner();
			}
		}
		
		public static List<T> DesordenarLista<T>(List<T> input)
		{
			List<T> arr = input;
			List<T> arrDes = new List<T>();
			
			Random randNum = new Random();
			while (arr.Count > 0)
			{
				int val = randNum.Next(0, arr.Count - 1);
				arrDes.Add(arr[val]);
				arr.RemoveAt(val);
			}
			
			return arrDes;
		}
		
	}
}

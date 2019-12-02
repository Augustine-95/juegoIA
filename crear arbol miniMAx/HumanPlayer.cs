
using System;
using System.Collections.Generic;
using System.Linq;


namespace juegoIA
{

	public class HumanPlayer : Jugador
	{
		private List<int> naipes = new List<int>();
		private List<int> naipesComputer = new List<int>();
		private int limite;
		private bool random_card = false;
		
		
		public HumanPlayer(){}
		
		public HumanPlayer(bool random_card)
		{
			this.random_card = random_card;
		}
		
		
		public override void  inicializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.naipes = cartasPropias;
			this.naipesComputer = cartasOponente;
			this.limite = limite;
		}
		
		
		public override int descartarUnaCarta()
		{
			int carta = 0;
			Console.WriteLine("Naipes disponibles (Usuario):");
			for (int i = 0; i < naipes.Count; i++) {
				Console.Write(naipes[i].ToString());
				if (i<naipes.Count-1) {
					Console.Write(", ");
				}
			}
			
			Console.WriteLine();
			if (!random_card) 
			{
				Console.WriteLine("Ingrese naipe o 0 para nueva partida/salir: ");
				string entrada = (Console.ReadLine());
				
				if(entrada == "0")
				{
					return 0;
				}
				
				Int32.TryParse(entrada, out carta);
				while (!naipes.Contains(carta)) 
				{
					Console.Write("Opcion Invalida.Ingrese otro naipe:");
					entrada = Console.ReadLine();
					Int32.TryParse(entrada, out carta);
				}
			}
			else
			{
				var random = new Random();
				int index = random.Next(naipes.Count);
				carta = naipes[index];
				Console.Write("Ingrese naipe:" + carta.ToString());
			}
			return carta;
		}
		
		
		public override void cartaDelOponente(int carta)
		{
		}
			
	}
}

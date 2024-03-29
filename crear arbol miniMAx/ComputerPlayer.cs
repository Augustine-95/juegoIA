﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		private ArbolGeneral arbol;
		private int limite=0;
		private int cartaOponente;
		private List<int> cartas;
		
		public ComputerPlayer()
		{
		}
		
		public override void  inicializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			NodoGeneral raiz= new NodoGeneral(0,0);
			ArbolGeneral arbol= new ArbolGeneral(raiz);
			arbol.agregarHijos(cartasOponente,limite);
			
			foreach (NodoGeneral n in raiz.getHijos())
			{
				llenarArbol(n,cartasPropias,cartasOponente,limite);
			}
			
			this.arbol= arbol;
			this.limite= limite;
			cartas= cartasPropias;
		}
		
		private void llenarArbol(NodoGeneral nodo, List<int> mazoPropias, List<int> mazoOponente,int lim)
		{
			List<int> mPropias= new List<int>();
			List<int> mOponente= new List<int>();
			List<int> mOponenteAux= new List<int>();
			int limite,limAux;
			
			
			nuevaLista(mazoPropias,mPropias);
			nuevaLista(mazoOponente,mOponente);
			
			if( mPropias.Count != 0 && mOponente.Count != 0)
			{
				limite= lim-nodo.getDato();
				
				foreach(int i in mPropias)
				{
					nodo.setHijos(i,limite);
					
				}
				
				mOponente.Remove(nodo.getDato());
				
				nuevaLista(mOponente,mOponenteAux);
				
				limAux= limite;

				foreach(NodoGeneral ng in nodo.getHijos())
				{
					llenarArbol (ng, mOponente, mPropias,limite);
					
					mPropias.Clear();
					nuevaLista(mazoPropias,mPropias);
					
					mOponente.Clear();
					nuevaLista(mOponenteAux,mOponente);
					limite=limAux;
					
				}
			}
		}
		
		private void nuevaLista(List<int> loriginal,List<int> lnueva)
		{
			foreach(int i in loriginal)
			{
				lnueva.Add(i);
			}
		}
		
		public override int descartarUnaCarta()
		{
			int cartaADescartar=0;
			int mayor=-1000;
			int evaluacion;

			Console.WriteLine("Naipes disponibles (Computer):");
			for (int i = 0; i < cartas.Count; i++) {
				Console.Write(cartas[i].ToString());
				if (i<cartas.Count-1) {
					Console.Write(", ");
				}
			}
			Console.WriteLine();
			Console.WriteLine("Carta eliminada:");
			
			foreach (NodoGeneral hijo in arbol.raiz.getHijos())
			{
				if( hijo.getDato() == cartaOponente)
				{
					foreach(NodoGeneral nieto in hijo.getHijos())
					{
						if(limite - nieto.getDato() > 0)
						{
							evaluacion= evaluarNodo(nieto,"PC");
							if(evaluacion > mayor)
							{
								mayor=evaluacion;
								cartaADescartar= nieto.getDato();
							}
						}
					}
					
					/*if(cartaADescartar >= limite)
					{
						cartas.Sort();
						foreach(int c in cartas)
						{
							if(c< limite)
							{
								cartaADescartar= c;
							}
						}
					}*/
					
					if(cartaADescartar == 0)
					{
						cartas.Sort();
						foreach(int c in cartas)
						{
							if(c< limite)
							{
								cartaADescartar= c;
							}
						}

					}
					
					if(cartaADescartar == 0)
					{
						cartaADescartar= cartas[0];
					}
					
					foreach(NodoGeneral n in hijo.getHijos())
					{
						if (n.getDato() == cartaADescartar)
						{
							arbol.raiz.setHijos(n.getHijos());
						}
					}
					
				}
			}
			
			cartas.Remove(cartaADescartar);
			limite-= cartaADescartar;
			
			return cartaADescartar;
		}
		
		private int evaluarNodo(NodoGeneral nodo, string tipo)
		{
			
			int total= 0;
			
			if(nodo.getLimite() <= 0)
			{
				if(tipo == "PC")
				{
					total= 1;
				}
				else
				{
					total= -1;
				}
			}
			else
			{
				if(nodo.getHijos().Count != 0)
				{
					if(tipo == "PC")
					{
						tipo= "user";
					}
					else
					{
						tipo= "PC";
					}
					foreach(NodoGeneral n in nodo.getHijos())
					{
						total+=evaluarNodo(n,tipo);
					}
				}
			}
			return total;
		}
		
		private int evaluarNodo2(NodoGeneral nodo)
		{
			int may=0;
			int mayAux;
			
			if(nodo.getHijos().Count == 0)
			{
				return nodo.getLimite();
			}
			else
			{
				foreach (NodoGeneral n in nodo.getHijos())
				{
					mayAux= n.getLimite()+evaluarNodo2(n);
					if(mayAux > may)
					{
						may=mayAux;
					}
				}
			}
			
			return may;
		}
		
		
		public override void cartaDelOponente(int carta)
		{
			cartaOponente= carta;
			limite-=carta;
		}
		
	}

}





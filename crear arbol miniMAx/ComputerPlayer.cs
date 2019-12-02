
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		private ArbolGeneral arbol;
		private int limite;
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
			devolverCartas();
			int mayor=0;
			int evaluacion;
			Console.WriteLine("Carta eliminada:");
		
			
			foreach (NodoGeneral hijo in arbol.raiz.getHijos())
			{
				if( hijo.getDato() == cartaOponente)
				{
					foreach(NodoGeneral nieto in hijo.getHijos())
					{
						if(limite >= nieto.getDato())
						{
							evaluacion= evaluarNodo(nieto);
							if(evaluacion > mayor)
							{
								mayor=evaluacion;
								cartaADescartar= nieto.getDato();
								this.arbol.raiz.setHijos(nieto.getHijos());
							}
						}
						
					}
				}
			}
			this.cartas.Remove(cartaADescartar);
			
			return cartaADescartar;
		}
		
		private int evaluarNodo(NodoGeneral nodo)
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
					mayAux= n.getLimite()+evaluarNodo(n);
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
		
		public void devolverCartas()
		{
			string cartas="";
			foreach(int c in this.cartas)
			{
				cartas+=c+" ";
			}
			Console.WriteLine("Cartas bot: "+cartas);
		}
	}

}





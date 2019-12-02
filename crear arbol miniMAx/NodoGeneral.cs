using System;
using System.Collections.Generic;

namespace juegoIA
{
	
	public class NodoGeneral
	{
		private int dato;
		private List<NodoGeneral> hijos;
		private int limite;
		
		
		public NodoGeneral(int dato,int lim)
		{
			this.dato = dato;
			this.hijos = new List<NodoGeneral>();
			this.limite= lim;
		}
	
		
		public int getDato()
		{
			return this.dato; 
		}
	
		
		public List<NodoGeneral> getHijos()
		{
			return this.hijos;
		}

		
		public void setDato(int dato)
		{
			this.dato = dato;
		}
		
		
		public void setHijos(int dato, int lim)
		{
			this.hijos.Add(new NodoGeneral(dato,lim));
		}
		
		
		public void setHijos(List<NodoGeneral> hijos)
		{
			this.hijos= hijos;
		}
		
		
		public int getLimite()
		{
			return limite;
		}
				
	}
}

using System;
using System.Collections.Generic;

namespace juegoIA
{
	
	public class ArbolGeneral
	{
		
		public NodoGeneral raiz;

		public ArbolGeneral(int dato,int lim)
		{
			this.raiz = new NodoGeneral(dato,lim);
		}
		
		
		public ArbolGeneral(NodoGeneral nodo)
		{
			this.raiz = nodo;
		}
		
		
		public void agregarHijos(List<int> hijos,int lim)
		{
			foreach(int hijo in hijos)
			{
				this.raiz.setHijos(hijo,lim);
			}
		}
		
		
		/*private NodoGeneral getRaiz()
		{
			return raiz;
		}
	
		public int getDatoRaiz()
		{
			return this.getRaiz().getDato();
		}
	
		public List<NodoGeneral> getHijos()
		{

		}
			
		public void eliminarHijo(ArbolGeneral hijo)
		{
			this.raiz.getHijos().Remove(hijo.getRaiz());
		}
	
		public bool esVacio()
		{
			return this.raiz == null;
		}
	
		public bool esHoja()
		{
			return this.raiz != null && this.getHijos().Count == 0;
		}
	
		public int altura()
		{
			return 0;
		}*/
		
	}
}



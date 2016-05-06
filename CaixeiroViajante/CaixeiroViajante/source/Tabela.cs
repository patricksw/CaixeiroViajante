using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    class Tabela
    {
        private int resultado;
        private int[] rota;

        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        public int[] Rota
        {
            get { return rota; }
            set { rota = value; }
        }

        /// <summary>
        /// Este construtor cria uma novo item do tipo 'Tabela', cada item tem o resultado da distancia da rota e a rota
        /// </summary>
        public Tabela(int resultado, int[] rota)
        {
            this.Resultado = resultado;
            this.Rota = rota;
        }
    }
}

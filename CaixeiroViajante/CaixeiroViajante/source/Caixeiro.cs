using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    class Caixeiro
    {
        private DataTable melhorrota;
        private int totaldistancia;

        public DataTable MelhorRota
        {
            get { return melhorrota; }
            set { melhorrota = value; }
        }
        public int TotalDistancia
        {
            get { return totaldistancia; }
            set { totaldistancia = value; }
        }
        /// <summary>
        /// Este construtor resolve o algoritmo
        /// Origem = index da capital de origem
        /// Populacao = total de populacao a ser criada
        /// FatorCruzamento = indica onde o cromossomo deve ser dividido
        /// NumeroEra = indica a quantidade de eras ou quantidade de crossover deve ser aplicado a população
        /// CoefMutacao = indica a porcentagem de mutacao que deve ser aplicada em cada Era
        /// </summary>
        public Caixeiro(int origem, int populacao, int fatorCruzamento, int numeroEra, double coefMutacao)
        {
            Populacao pop = new Populacao(origem, populacao, fatorCruzamento, coefMutacao);

            for (int i = 0; i <= numeroEra; i++)
            {
                pop.Crossover();
            }

            ArrayRotaToTable(origem, pop.TabelaResultado[0].Rota.ToArray());
            this.TotalDistancia = pop.TabelaResultado[0].Resultado;
        }
        /// <summary>
        /// Este método apenas converte o array de inteiros (resultado final) em um tipo DataTable para ser exibino no formulario
        /// </summary>
        private void ArrayRotaToTable(int origem, int[] rota)
        {
            this.MelhorRota = new DataTable();

            Capital capital = new Capital();
            DataTable cidade = capital.Cidade;

            this.MelhorRota.Columns.Add("Percurso");
            this.MelhorRota.Rows.Add(cidade.Rows[origem][0].ToString());

            foreach (int item in rota)
            {
                this.MelhorRota.Rows.Add(cidade.Rows[item][0].ToString());
            }
            this.MelhorRota.Rows.Add(cidade.Rows[origem][0].ToString());
        }
    }
}

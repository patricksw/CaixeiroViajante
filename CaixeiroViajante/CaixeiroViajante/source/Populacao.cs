using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    class Populacao
    {
        private int total;
        private int fatorcruzamento;
        private int geneprimario;

        public const int TotalCromossomo = 25;
        private Random rand = new Random(DateTime.Now.Millisecond - 5);
        public List<Tabela> TabelaResultado = new List<Tabela>();
        private double coefmutante;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        public int FatorCruzamento
        {
            get
            {
                if (fatorcruzamento == 0)
                {
                    fatorcruzamento = (int)TotalCromossomo / 2;
                }
                return fatorcruzamento;
            }
            set { fatorcruzamento = value; }
        }
        public int GenePrimario
        {
            get { return geneprimario; }
            set { geneprimario = value; }
        }
        public double CoefMutante
        {
            get { return coefmutante; }
            set { coefmutante = value; }
        }

        /// <summary>
        /// Este método ordena a tabela de resultados pela menor distância
        /// Elimina os itens da tabela maiores que o total da população
        /// </summary>
        public void TabelaSort()
        {
            this.TabelaResultado = TabelaResultado.OrderBy(o => o.Resultado).ToList();
            this.TabelaResultado.RemoveRange(this.Total - 1, ((this.TabelaResultado.Count - 1) - (this.Total - 1)));
        }

        /// <summary>
        /// Este construtor gera uma nova população respeitando os parâmetros informados
        /// Cada item individuo da população é um item do tipo Tabela
        /// Cada individo tem uma rota aleatória e um total de distância
        /// A variável TabelaResultado é uma lista dinâmica do tipo tabela
        /// Ao concluir a população A TabelaResultado é ordenada
        /// </summary>
        public Populacao(int origem, int total, int fator, double coefMutacao)
        {
            this.GenePrimario = origem;
            this.Total = total;
            this.FatorCruzamento = fator;
            this.CoefMutante = coefMutacao;

            for (int i = 0; i < this.Total; i++)
            {
                int[] rota = Rota.CriaRota(this.GenePrimario, TotalCromossomo, rand.Next(0, this.total));
                this.TabelaResultado.Add(new Tabela(Rota.Fitness(this.GenePrimario, rota.ToArray()), rota.ToArray()));
            }
            TabelaSort();
        }

        /// <summary>
        /// Este método recebe como parãmetro uma rota
        /// Ele consiste em realizar um sorteio de 2 index da rota e trocá-los
        /// </summary>
        private int[] Mutacao(int[] s)
        {
            int r1 = rand.Next(0, s.Length - 1);
            int r2 = rand.Next(0, s.Length - 1);

            int temp = s[r1];
            s[r1] = s[r2];
            s[r2] = temp;

            return s.ToArray();
        }

        /// <summary>
        /// Este método recebe 2 cromossos(array de rotas)
        /// Também recebe mais 4 parâmetros que indicam onde terminam e iniciam os arrays de rotas
        /// O objetivo mesclar as 2 rotas enviadas como parâmetro e retornar uma nova rota mesclada
        /// </summary>
        private int[] arrayCopy(int[] array1, int[] array2, int iniArray1, int fimArray1, int iniArray2, int fimArray2)
        {
            int[] novaRota = new int[TotalCromossomo];

            for (int i = iniArray1; i <= fimArray1; i++)
            {
                novaRota[i] = array1[i];
            }

            for (int i = iniArray2; i < fimArray2; i++)
            {
                novaRota[i] = array2[i];
            }
            return novaRota.ToArray();
        }

        /// <summary>
        /// Este método recebe como parâmetro um array de rota
        /// Ele tem como objetivo garantir que a rota não fique repetida
        /// Portanto ele indica as capitais faltantes e as capitais repetidas
        /// Depois dubistitui elas
        /// </summary>
        private int[] resolveRepetidos(int[] rota)
        {
            int origem = this.GenePrimario;

            int[] list = new int[26] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

            List<int> repetidos = new List<int>();
            List<int> faltam = new List<int>();

            for (int i = 0; i < list.Length - 1; i++)
            {
                int n = rota[i];

                if (list[n] != origem)
                {
                    if (list[n] == -1)
                    {
                        list[n] = n;
                    }
                    else
                    {
                        repetidos.Add(i);
                    }
                }
            }

            if (repetidos.Count <= 0)
                return rota;

            for (int i = 0; i < list.Length; i++)
            {
                if (i != origem)
                {
                    if (list[i] == -1)
                    {
                        faltam.Add(i);
                    }
                }
            }

            for (int i = 0; i < repetidos.Count; i++)
            {
                int r = repetidos[i];

                rota[r] = faltam[i];
            }

            return rota.ToArray();
        }

        /// <summary>
        /// Este método percorre toda a população mexclando cada cromossomo
        /// </summary>
        public void Crossover()
        {
            int i = 0;
            while (i < this.Total - 1)
            {
                int[] novaRota1 = new int[TotalCromossomo];
                int[] novaRota2 = new int[TotalCromossomo];

                novaRota1 = arrayCopy(this.TabelaResultado[i].Rota.ToArray(), this.TabelaResultado[i + 1].Rota.ToArray(), 0, this.FatorCruzamento, this.FatorCruzamento + 1, TotalCromossomo).ToArray();
                novaRota2 = arrayCopy(this.TabelaResultado[i + 1].Rota.ToArray(), this.TabelaResultado[i].Rota.ToArray(), 0, this.FatorCruzamento, this.FatorCruzamento + 1, TotalCromossomo).ToArray();

                int mutcao1 = rand.Next(0, total);
                int mutcao2 = rand.Next(0, total);

                novaRota1 = resolveRepetidos(novaRota1.ToArray());
                novaRota2 = resolveRepetidos(novaRota2.ToArray());

                if (mutcao1 <= (int)(total * this.CoefMutante))
                {
                    novaRota1 = Mutacao(novaRota1.ToArray()).ToArray();
                }

                if (mutcao2 <= (int)(total * this.CoefMutante))
                {
                    novaRota2 = Mutacao(novaRota2.ToArray()).ToArray();
                }

                this.TabelaResultado.Add(
                    new Tabela(Rota.Fitness(this.GenePrimario, novaRota1.ToArray()), novaRota1.ToArray())
                    );

                this.TabelaResultado.Add(
                    new Tabela(Rota.Fitness(this.GenePrimario, novaRota2.ToArray()), novaRota2.ToArray())
                    );

                i++;
                i++;

            }
            TabelaSort();
        }
    }
}

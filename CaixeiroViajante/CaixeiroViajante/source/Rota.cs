    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    class Rota
    {
        /// <summary>
        /// Origem = Cidade de Origem;
        /// max = Maximo de intens da Rota;
        /// </summary>
        public static int[] CriaRota(int origem, int max, int rand)
        {
            //Random rnd = new Random(rand + DateTime.Now.Millisecond);

            //int[] rota = Enumerable.Range(0, 26)
            //                    .Select(x => new { val = x, order = rnd.Next() })
            //                    .OrderBy(i => i.order)
            //                    .Select(x => x.val)
            //                    .ToArray();

            Random r = new Random(rand);

            List<int> dimamicRota = new List<int>();

            for (int i = 0; i <= max; i++)
            {
                if (origem != i)
                {
                    dimamicRota.Add(i);
                }
            }

            int[] rota = dimamicRota.ToArray();

            for (int i = 0; i < rota.Length; i++)
            {
                int s = r.Next(0, rota.Length - 1);
                int t = rota[i];

                rota[i] = rota[s];
                rota[s] = t;
            }
            return rota.ToArray();
        }

        /// <summary>
        /// Este método calcula o total de distância da rota
        /// Origem = Cidade de Origem;
        /// Rota = array de inteiros, cada inteiro representa uma capital
        /// </summary>
        public static int Fitness(int origem, int[] rota)
        {
            int result = 0;

            Capital capital = new Capital();

            result += capital.Distancia(origem, rota[0]);

            for (int i = 0; i < rota.Length - 1; i++)
            {
                int capital1 = rota[i];
                int capital2 = rota[i + 1];

                result += capital.Distancia(capital1, capital2);
            }

            result += capital.Distancia(rota[rota.Length - 1], origem);
            return result;
        }
    }
}

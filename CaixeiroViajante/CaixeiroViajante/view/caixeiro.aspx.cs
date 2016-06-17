using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaixeiroViajante.view
{
    public partial class caixeiro : System.Web.UI.Page
    {
        private int origem;
        private int populacao;
        private int fatorcruzamento;
        private int numeroeras;
        private double coefmutante;

        public int Origem
        {
            get { return origem; }
            set { origem = value; }
        }
        public int Populacao
        {
            get { return populacao; }
            set { populacao = value; }
        }
        public int FatorCruzamento
        {
            get { return fatorcruzamento; }
            set { fatorcruzamento = value; }
        }
        public int NumeroEras
        {
            get { return numeroeras; }
            set { numeroeras = value; }
        }
        public double CoefMutante
        {
            get { return coefmutante; }
            set { coefmutante = value; }
        }

        protected void SelCidade()
        {
            dpdCidade.DataTextField = "NomeCidade";
            dpdCidade.DataValueField = "IDCidade";
            dpdCidade.DataSource = new Capital().Cidade;
            dpdCidade.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelCidade();
            }
        }

        protected void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataini = DateTime.Now;

                Origem = Convert.ToInt32(dpdCidade.SelectedValue);
                Populacao = Convert.ToInt32(txtPopulacao.Text);
                FatorCruzamento = Convert.ToInt32(dpdFatorCruzamento.SelectedValue);
                NumeroEras = Convert.ToInt32(txtNumeroDeEras.Text);
                CoefMutante = Convert.ToDouble(dpdFatorMutacao.SelectedValue);

                Caixeiro caixeiro = new Caixeiro(Origem, Populacao, FatorCruzamento, NumeroEras, CoefMutante);

                grvPercurso.DataSource = caixeiro.MelhorRota;
                grvPercurso.DataBind();

                lbTotalDistancia.Text = "Distância Total..: " + caixeiro.TotalDistancia.ToString() + "km";
                lbCapitalOrigemDestino.Text = "Capital Origem/Destino: " + caixeiro.MelhorRota.Rows[0][0].ToString();
                lbCapitaisPercorridas.Text = "Capitais Percorridas..: " + caixeiro.MelhorRota.Rows.Count.ToString();

                DateTime datafim = DateTime.Now;

                lbTempoAlgoritmo.Text = "Tempo: " + datafim.Subtract(dataini).TotalSeconds + "sec";
            }
            catch (Exception ex)
            {
                lbErro.Text = "Erro ao calcular rota: " + ex.ToString();
            }
        }
    }
}
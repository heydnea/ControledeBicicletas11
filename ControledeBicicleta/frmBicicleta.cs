using Entidade;
using ControleBanco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControledeBicicleta
{
    public partial class frmBicicleta : Form
    {
        public frmBicicleta()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            Bicicleta bici = new Bicicleta();
           
            bici.Modelo = txtModelo.Text;
            bici.dtFabricacao = Convert.ToDateTime(txtDtFabricacao.Text); 
            bici.fabricante = Convert.ToInt32( cbFabricante.SelectedItem);

            //MessageBox.Show("Olá turma!" + tipo);

            if (new BicicletaDB().insert(bici))
            {
                MessageBox.Show("Registro inserido!");
                txtModelo.Text = "";
                txtDtFabricacao.Text = "";
                cbFabricante.SelectedItem = 0;
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Erro ao inserir registro!");
            }
        }
        private void CarregarGrid()
        {
            dgBicicleta.DataSource = new BicicletaDB().ListarBicicleta();
        }

        private void frmBicicleta_Load(object sender, EventArgs e)
        {

            CarregarGrid();
            var fab = new FabricanteDB().ListarFabricante();
            foreach (var item in fab)
            {
                cbFabricante.Items.Add(item.Id);
            }
        }
    }
}

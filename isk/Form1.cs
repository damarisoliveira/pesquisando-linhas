using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataRow _obj = ((DataRowView)Grid.CurrentRow.DataBoundItem).Row;

            pesquisarPorCodigo();

         
        }
        void pesquisarPorCodigo()
        {
            bool achou = false;
            Grid.ClearSelection();
            foreach (DataGridViewRow row in Grid.Rows) {

                DataRow obj = ((DataRowView)row.DataBoundItem).Row;

                if (txtBox.Text == obj["Codigo"].ToString())
                {
                    achou = true;
                    selecionarCelulasDaLinha(row);  
                    
                }
            }
            if (!achou)
            {
                MessageBox.Show("Não achou!!!");
            }
        }

        void selecionarCelulasDaLinha(DataGridViewRow row)
        {
            foreach (DataGridViewTextBoxCell cell in row.Cells)
            {
                cell.Selected = true;
            }
        }

        class EtiquetaConferenciaProduto
        {
          
            public int Codigo { get; set; }
            public string Produto { get; set; }

            public EtiquetaConferenciaProduto(int codigo, string produto)
            {
                Codigo = codigo;
                Produto = produto;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable tb = new DataTable();
            tb.Columns.Add(new DataColumn("Codigo", typeof(Int32)));
            tb.Columns.Add(new DataColumn("Produto", typeof(string)));
           
            DataRow rw1 = tb.NewRow();
            rw1["Codigo"] = 24442;
            rw1["Produto"] = "Lampada";

            DataRow rw2 = tb.NewRow();
            rw2["Codigo"] = 23221;
            rw2["Produto"] = "Bicicleta";

            DataRow rw3 = tb.NewRow();
            rw3["Codigo"] = 23221;
            rw3["Produto"] = "Bicicleta";

            tb.Rows.Add(rw1);
            tb.Rows.Add(rw2);
            tb.Rows.Add(rw3);

            
            //Grid.AutoGenerateColumns = false;
            Grid.DataSource = tb;

            Grid.ClearSelection();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow _row = ((DataRowView)Grid.Rows[e.RowIndex].DataBoundItem).Row;
           // MessageBox.Show("ensagem saida = " + _row);


        }
    }
}

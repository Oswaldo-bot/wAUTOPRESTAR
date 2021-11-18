using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/// <summary>
/// Oswaldo Duran Chaverra
/// 2021/11/17
/// </summary>
namespace wAUTOPRESTAR
{
    public partial class FrmAuto : Form
    {
        public FrmAuto()
        {
            InitializeComponent();
        }

        private void datosUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos_Usuarios FrmHijo1 = new Datos_Usuarios();
            FrmHijo1.MdiParent = this;
            FrmHijo1.Show();
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dato_Auto FrmHijo2 = new Dato_Auto();
            FrmHijo2.MdiParent = this;
            FrmHijo2.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmHijo = this.ActiveMdiChild;
            if (frmHijo != null)
            {
            frmHijo.Close();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void guadarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
                {
                    Stream strGuardar = saveFileDialog1.OpenFile();
                    StreamWriter wrtGuardar = new StreamWriter(strGuardar);
                    foreach (string linea in textBox1.Lines)
                    {
                        wrtGuardar.WriteLine(linea);
                    }


                    wrtGuardar.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

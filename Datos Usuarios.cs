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

namespace wAUTOPRESTAR
{
    public partial class Datos_Usuarios : Form
    {
        public Datos_Usuarios()
        {
            InitializeComponent();
            IniciarComponentes();
           
        }

        private void Datos_Usuarios_Load(object sender, EventArgs e)
        {

        }

        public void IniciarComponentes() 
        {
            #region[cargar los items de los comboBox]

            //Llenar Combo EPS

            cmbEPS.Items.Clear();
            cmbEPS.Items.Add("");
            cmbEPS.Items.Add("Medimas");
            cmbEPS.Items.Add("Nueva EPS");
            cmbEPS.Items.Add("Salud Total");
            cmbEPS.Items.Add("Sura");
            cmbEPS.Items.Add("Sanitas");
            cmbEPS.Items.Add("Compensar");
            cmbEPS.Items.Add("Cafesalud");
            cmbEPS.Items.Add("Comfama");
            cmbEPS.Items.Add("Confenalco");

            #endregion
        }

        //Lo utilizamos para un resumen

        private void btnResumen_Click(object sender, EventArgs e)
        {
            ValidarCampos();

            MessageBox.Show("Nombre:\t: " + txtNombre.Text + "\r\n" +
                          "Apellido \t:" + txtApellido.Text + "\r\n"+
                          "Cedula \t:" + txtCedula.Text + "\r\n"+
                          "Fecha De Nacieminto \t:" + dtpFecha.Text + "\r\n" +
                          "Celular \t:" + txtCelular.Text + "\r\n" +
                          "Telefono \t:" + txtTelefono.Text + "\r\n" +
                          "Codigo Usuario \t:" + txtCodigo.Text + "\r\n" +
                          "EPS \t:" + cmbEPS.Text + "\r\n" +
                           "La Información a Sido Revisada");
        }

        //El  Boton Salir

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Se Creo El Boton Limpiar

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar limpiar = new Limpiar();
            limpiar.BorrarCampos(this);
        }


        //Boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
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

        private bool ValidarCampos()
        {
            bool ok = true;

            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingresar Un Nombre");
            }

            if (txtApellido.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtApellido, "Ingresar un Apellido");
            }

            if (txtDireccion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDireccion, "Ingresar Una Dirreccion");
            }

            if (txtCodigo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCodigo, "Dar un cogido al Usuario");
            }

            if (txtCelular.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCelular, "Dar un cogido al Usuario");
            }

            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCedula, "Dar un cogido al Usuario");
            }

            if (dtpFecha.Text == "")
            {
                ok = false;
                errorProvider1.SetError(dtpFecha, "Selecionar un Fecha Valida");
            }

            if (dtpExpedicion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(dtpExpedicion, "Selecionar un Fecha Valida");
            }

            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Ingresar Un telefono");
            }

            if (cmbEPS.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cmbEPS, "Escoger Un EPS");
            }
            return ok;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }
    }
}

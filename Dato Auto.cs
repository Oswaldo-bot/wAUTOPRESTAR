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
    public partial class Dato_Auto : Form
    {
        public Dato_Auto()
        {
            InitializeComponent();
            IniciarComponentes();
         
        }

        public void IniciarComponentes()
        {
            errorProvider1.Clear();

            #region[cargar los items de los comboBox]

            // Llenar Combo Compañia De Seguros

            cmbSeguro.Items.Clear();
            cmbSeguro.Items.Add("");
            cmbSeguro.Items.Add("Zurich");
            cmbSeguro.Items.Add("Compañía Mundial");
            cmbSeguro.Items.Add("La Previsora");
            cmbSeguro.Items.Add("Axa Colpatria");
            cmbSeguro.Items.Add("HDI Seguros");
            cmbSeguro.Items.Add("SBS Seguros");
            cmbSeguro.Items.Add("Bolívar");
            cmbSeguro.Items.Add("Equidad");
            cmbSeguro.Items.Add("Seguros del Estado");
            cmbSeguro.Items.Add(" Liberty Seguros");
            cmbSeguro.Items.Add("Mapfre");
            cmbSeguro.Items.Add("Aseguradora Solidaria");
            cmbSeguro.Items.Add("Allianz Seguros");
            cmbSeguro.Items.Add("Sura");

            // Llenar Combo Modelo

            cmbModelo.Items.Clear();
            cmbModelo.Items.Add("");
            cmbModelo.Items.Add("Kwid");
            cmbModelo.Items.Add("Duster");
            cmbModelo.Items.Add("Stepway");
            cmbModelo.Items.Add("Logan");
            cmbModelo.Items.Add("Sandero");
            cmbModelo.Items.Add("Onix");
            cmbModelo.Items.Add("Tracker");
            cmbModelo.Items.Add("Beat");
            cmbModelo.Items.Add("Joy");
            cmbModelo.Items.Add("NHR");
            cmbModelo.Items.Add("CX-30");
            cmbModelo.Items.Add("Mazda 2");
            cmbModelo.Items.Add("CX-5");
            cmbModelo.Items.Add("Mazda 3");
            cmbModelo.Items.Add("CX-9");
            cmbModelo.Items.Add("Versa");
            cmbModelo.Items.Add("Kicks");
            cmbModelo.Items.Add("March");
            cmbModelo.Items.Add("Frontier");
            cmbModelo.Items.Add("Qashqai");
            cmbModelo.Items.Add("Picanto");
            cmbModelo.Items.Add("Sportage");
            cmbModelo.Items.Add("Rio");
            cmbModelo.Items.Add("Eko Taxi");
            cmbModelo.Items.Add("Tonic");
            cmbModelo.Items.Add("Corolla");
            cmbModelo.Items.Add("SW4 Fortuner");
            cmbModelo.Items.Add("Hilux");
            cmbModelo.Items.Add("Prado");
            cmbModelo.Items.Add("Yaris");
            cmbModelo.Items.Add("Gol");
            cmbModelo.Items.Add("Tucson");
            cmbModelo.Items.Add("Ranger");

            #endregion
        }

        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Boton Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar limpiar = new Limpiar();
            limpiar.BorrarCampos(this);
        }

        //Boton resumen
        private void btnResumen_Click(object sender, EventArgs e)
        {
            

            MessageBox.Show("Modelo: " + cmbModelo.Text + "\r\n" +
                       "Numero de Seguro \t:" + cmbSeguro.Text + "\r\n" +
                       "SOAP \t:" + txtSoap.Text + "\r\n" +
                       "Placa \t:" + txtPlaca.Text + "\r\n" +
                        "La Información a Sido Revisada");

        }

        // Boton Guardar 
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

        // Valir campos para el error 

        private bool ValidarCampos()
        {
            bool ok = true;

            if (txtPlaca.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtPlaca, "Ingresar Placa");
            }

            if(txtSoap.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtSoap, "Ingresar Numero de Soap");
            }

            if(cmbModelo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cmbModelo, "Seleccionar un Modelo de Auto");
            }

            if(cmbSeguro.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cmbSeguro, "Ingresar el Nombre del seguro");
            }
            return ok;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }
    }
}
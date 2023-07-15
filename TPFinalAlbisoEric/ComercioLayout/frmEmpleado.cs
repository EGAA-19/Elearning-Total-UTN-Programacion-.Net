using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComercioEntities;
using ComercioBusiness;


namespace ComercioLayout
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private Empleado empleado = new Empleado();
        public frmEmpleado(int ID)
        {
            InitializeComponent();
            empleado = EmpleadoBusiness.ObtenerEmpleado(ID);

            txtNombreCompleto.Text = empleado.NombreCompleto;
            txtDNI.Text = empleado.Edad.ToString();
            txtEdad.Text = empleado.Edad.ToString();
            ckbxCasado.Checked = empleado.Casado;
            txtSalario.Text = empleado.Salario.ToString();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Ingrese todos los campos requeridos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            empleado.NombreCompleto = txtNombreCompleto.Text;
            empleado.DNI = int.Parse(txtDNI.Text);
            empleado.Edad = int.Parse(txtEdad.Text);
            empleado.Casado = ckbxCasado.Checked;
            empleado.Salario = decimal.Parse(txtSalario.Text);

            EmpleadoBusiness.AltaModEmpleado(empleado);

            MessageBox.Show("Se guardo el Empleado con exito");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MostrarError("Debe ingresar un nombre.");
                return false;
            }

            if (!ValidarNumeroTextBox(txtDNI))
            {
                return false;
            }

            if (!ValidarNumeroTextBox(txtEdad))
            {
                return false;
            }

            if (!ValidarNumeroTextBox(txtSalario))
            {
                return false;
            }

            return true;
        }

        private bool ValidarNumeroTextBox(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MostrarError("Debe ingresar un valor numérico.");
                return false;
            }

            int numero;
            if (!int.TryParse(textBox.Text, out numero))
            {
                MostrarError("Debe ingresar un número válido.");
                return false;
            }

            return true;
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error de validacion");
        }
    }
}

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
    public partial class frmListadoEmpleados : Form
    {
        public frmListadoEmpleados()
        {
            InitializeComponent();
            FormStyle();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmEmpleado empleado = new frmEmpleado();
            empleado.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Empleado_FormClosed);
            empleado.ShowDialog();
        }

        private void Empleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.DataSource = EmpleadoBusiness.ListarEmpleados(txtNombreCompleto.Text);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void frmListadoEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                int id = (int)dgvEmpleados.SelectedRows[0].Cells["Id"].Value;
                frmEmpleadoEditable(id);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                int id = (int)dgvEmpleados.SelectedRows[0].Cells["Id"].Value;
                EliminarEmpleado(id);
            }
        }

        private void frmEmpleadoEditable(int id)
        {
            frmEmpleado empleado = new frmEmpleado(id);
            empleado.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Empleado_FormClosed);
            empleado.ShowDialog();
        }

        private void EliminarEmpleado(int id)
        {
            if (MessageBox.Show("¿Estas Seguro de eliminar al Empleado?", "Empleado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EmpleadoBusiness.EliminarEmpleado(id);
                MessageBox.Show("Se elimino correctamente el Empleado");
                CargarEmpleados();
            }
        }

        private void FormStyle()
        {
            dgvEmpleados.DefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvEmpleados.DefaultCellStyle.ForeColor = Color.White;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;

            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvEmpleados.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            dgvEmpleados.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
        }

    }
}

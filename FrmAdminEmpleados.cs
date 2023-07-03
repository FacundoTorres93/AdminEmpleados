using AdminEmpleadosEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleadosNegocio;

namespace AdminEmpleadosFront
{
    public partial class FrmAdminEmpleados : Form
    {
        //  // Lista para almacenar los empleados obtenidos
        List<Empleado> empleadosList = new List<Empleado>();

        public FrmAdminEmpleados()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarEmpleados();
        }
        private void buscarEmpleados()
        {
            //Obtengo el nombre ingresado por el usuario
            string nombreBuscar = txtBuscar.Text.Trim().ToUpper();

            //  Declaro el parámetro empleado para realizar la búsqueda
            Empleado parametro = new Empleado();

            // Asigno el nombre ingresado al parámetro empleado
            if (!String.IsNullOrEmpty(nombreBuscar.Trim()))
                parametro.Nombre = nombreBuscar;

            try
            {
                //Busco la lista de empleados en la capa de negocio, pasandole el parametro ingresado
                empleadosList = EmpleadosNegocio.Get(parametro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Actualizo la grilla  con los resultados de la búsqueda
            refreshGrid();
        }

        private void refreshGrid()
        {
            //Actualizo el Binding con la lista de empleados que viene desde la BD
            empleadoBindingSource.DataSource = null;
            empleadoBindingSource.DataSource = empleadosList;

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamo al metodo buscar al presionar la tecla "Enter"
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscarEmpleados();
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            // Abro el formulario FrmEditEmpleados en modo Alta
            FrmEditEmpleados frm = new FrmEditEmpleados();

            //paso por parametro "algo"
            frm.modo = EnumModoForm.Alta;

            // Abro el formulario de edición de empleados en modo modal
            frm.ShowDialog();

            // Actualizo la grilla después de cerrar el formulario de edición
            buscarEmpleados();
        }

        private void CargarDatosEmpleado()
        {

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            // Verifica si hay un empleado seleccionado en la grilla
            if (empleadoBindingSource.Current == null)
                return;

            // Abro el formulario FrmEditEmpleados en modo Consulta
            FrmEditEmpleados frm = new FrmEditEmpleados();
            //Paso por parámetro el modo de formulario(Consulta) y el empleado seleccionado
            frm.modo = EnumModoForm.Consulta;
            frm._empleado = (Empleado)empleadoBindingSource.Current;
            // Abro el formulario de edición de empleados en modo modal
            frm.ShowDialog();

            // Actualizo la grilla después de cerrar el formulario
            buscarEmpleados();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Verifica si hay un empleado seleccionado en la grilla
            if (empleadoBindingSource.Current == null)
                return;

            FrmEditEmpleados frm = new FrmEditEmpleados();

            // Paso por parámetro el modo de formulario (Modificación) y el empleado seleccionado
            frm.modo = EnumModoForm.Modificacion;
            frm._empleado = (Empleado)empleadoBindingSource.Current;

            frm.ShowDialog();
            // Actualizo la grilla después de cerrar el formulario
            buscarEmpleados();

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {  // Verifica si hay un empleado seleccionado en la grilla

            if (empleadoBindingSource.Current == null)
                return;

            // Obtiene el empleado seleccionado
            Empleado emp = (Empleado)empleadoBindingSource.Current;

            //pregunto si quiere guardar los datos pregunta si se desea anular al empleado
            DialogResult res = MessageBox.Show("¿Confirma anular el empleado " + emp.Nombre + " ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            // Establece el estado "anulado" del empleado
            emp.anulado = true;

            try
            { // Actualiza el estado del empleado en la capa de negocio
                EmpleadosNegocio.Update(emp);
                MessageBox.Show("El empleado " + emp.Nombre + " se anuló correctamente", "Anulación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            // Actualiza la grilla después de anular al empleado
            buscarEmpleados();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

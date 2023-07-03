using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // proporciona clases y tipos para trabajar con gráficos y dibujar en una variedad de contextos, como formularios, controles
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleadosEntidades;
using AdminEmpleadosNegocio;

namespace AdminEmpleadosFront
{

    public partial class FrmEditEmpleados : Form
    {
        // Enumeración que indica el modo de formulario (alta, modificación, consulta)
        public EnumModoForm modo = EnumModoForm.Alta;

        // Objeto de tipo Empleado que se utilizará para editar los datos
        public Empleado _empleado = new Empleado();
        public FrmEditEmpleados()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void Guardar()
        {
            try
            {
                //Creacion del objeto y carga los datos ingresados en un objeto empleado
                Empleado emp = new Empleado();
                emp.Salario = txtSalario.Value;
                emp.Direccion = txtDireccion.Text.Trim();
                emp.Dni = txtDni.Text.Trim();
                emp.FechaIngreso = txtIngreso.Value;
                emp.Departamento = null;
                emp.Nombre = txtNombre.Text.ToUpper().Trim();
                emp.Departamento = new Departamento();
                //tomo el ID del departamento, el cual esta en el combo
                emp.Departamento.id = (int)cmbDepartamento.SelectedValue;

                string mensajeErrores = "";
                //realizo validaciones. El mensaje va por referencia
                if (!ValidarEmpleado(ref mensajeErrores, emp))
                {
                    //si falla alguna validacion muestro el mensaje y no hago nada mas
                    MessageBox.Show("Atención: Se encontraron los siguientes errores \n" + mensajeErrores, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                //las validaciones estan bien
                //pregunto al usuario si quiere guardar los datos
                DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }

                //Guardo los datos segun alta y modificación

                if (modo == EnumModoForm.Alta)
                {
                    int idEmp = EmpleadosNegocio.Insert(emp);
                    txtId.Text = idEmp.ToString();
                    MessageBox.Show("Se generó el empleado nro " + idEmp.ToString(), "Empleado creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (modo == EnumModoForm.Modificacion)
                {
                    emp.id = Convert.ToInt32(txtId.Text);
                    EmpleadosNegocio.Update(emp);
                    MessageBox.Show("Se actualizaron los datos correctamente", "Empleado actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                // Limpiar los controles del formulario
                LimpiarControles();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarEmpleado(ref string mensaje, Empleado e)
        {
            mensaje = "";

            // Validación del campo DNI

            if (String.IsNullOrEmpty(e.Dni.Trim()))
            {
                mensaje += "\nError en DNI";
                errorProvider1.SetError(txtDni, "Ingrese el DNI");
            }

            // Validación del campo Nombre
            if (String.IsNullOrEmpty(e.Nombre.Trim()))
            {
                mensaje += "\nError en Nombre";
                errorProvider1.SetError(txtNombre, "Ingrese el nombre");
            }
            if (!String.IsNullOrEmpty(mensaje))
            {
                // Si hay errores, se limpia el errorProvider y se retorna falso
                errorProvider1.Clear();
                return false;
            }

            return true;
        }
        private void LimpiarControles()
        { // Limpiar los controles del formulario
            txtId.Text = "";
            txtSalario.Value = 0;
            txtDireccion.Text = "";
            txtDni.Text = "";
            txtIngreso.Value = DateTime.Now;
            txtNombre.Text = "";
        }
        private void FrmEditEmpleados_Load(object sender, EventArgs e)
        {     // Cargar el combo de departamentos al cargar el formulario
            CargarComboDepartamento();

            if (modo == EnumModoForm.Alta)
            {  // Si es un formulario de alta, limpiar los controles y habilitarlos
                LimpiarControles();
                HabilitarControles(true);
            }
            if (modo == EnumModoForm.Modificacion)
            {// Si es un formulario de modificación, habilitar los controles y cargar los datos del empleado
                HabilitarControles(true);
                CargarDatos();
            }
            if (modo == EnumModoForm.Consulta)
            {// Si es un formulario de consulta, deshabilitar los controles, cargar los datos del empleado y deshabilitar el botón Aceptar
                HabilitarControles(false);
                CargarDatos();
                btnAceptar.Enabled = false;
            }

        }

        private void CargarComboDepartamento()
        {
            //envio por parametro un departamento sin datos, asi va sin filtro y trae todos los dptos
            Departamento d = new Departamento();
            departamentoBindingSource.DataSource = DepartamentosNegocio.Get(d);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario
            Close();
        }
        private void HabilitarControles(bool habilitar)
        {
            // Habilitar o deshabilitar los controles del formulario según el parámetro "habilitar"
            txtSalario.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtDni.Enabled = habilitar;
            txtIngreso.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            cmbDepartamento.Enabled = habilitar;
        }
        private void CargarDatos()
        {  // Cargar los datos del empleado en los controles del formulario
            txtId.Text = _empleado.id.ToString();
            txtSalario.Value = Convert.ToDecimal(_empleado.Salario);
            txtDireccion.Text = _empleado.Direccion;
            txtDni.Text = _empleado.Dni;
            if (_empleado.FechaIngreso != null)
                txtIngreso.Value = Convert.ToDateTime(_empleado.FechaIngreso);
            txtNombre.Text = _empleado.Nombre;

            if (_empleado.Departamento != null)
                cmbDepartamento.SelectedValue = _empleado.Departamento.id;

        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {// Validar los campos DNI y Nombre al perder el foco
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(txtDni.Text.Trim()))
            {
                errorProvider1.SetError(txtDni, "Ingrese el DNI");
            }
            if (String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre");
            }

        }
    }
}

using BE;
using BL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class AutorForm : Form
    {
        private AutorBL autorBL = new AutorBL();
        public AutorForm()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string apellido = txt_apellido.Text;
            string nombre = txt_nombre.Text;
            DateTime fnacimiento = Convert.ToDateTime(dtp_fnacimiento.Value);
            int nacionalidad = Convert.ToInt32(cmbPaises.SelectedValue);

            AutorBE autorBE = new AutorBE(apellido, nombre, fnacimiento, nacionalidad);

            autorBL.Insert(autorBE);
            this.Listado_autores("%");
            MessageBox.Show("!Nuevo autor registrado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void CargarPaises()
        {
            AutorBL autorBL = new AutorBL();
            cmbPaises.DataSource = autorBL.ObtenerListadoPaises();
            cmbPaises.ValueMember = "ID";
            cmbPaises.DisplayMember = "Descripcion";
        }

        private void AutorForm_Load(object sender, EventArgs e)
        {
            this.CargarPaises();
            this.Listado_autores("%");
        }

        private void Formato_autores()
        {
            dgvAutores.Columns[0].Width = 60;
            dgvAutores.Columns[0].HeaderText = "ID";
            dgvAutores.Columns[1].Width = 100;
            dgvAutores.Columns[1].HeaderText = "APELLIDO";
            dgvAutores.Columns[2].Width = 100;
            dgvAutores.Columns[2].HeaderText = "NOMBRE";
            dgvAutores.Columns[3].Width = 140;
            dgvAutores.Columns[3].HeaderText = "FECHA NACIMIENTO";
            dgvAutores.Columns[4].Width = 100;
            dgvAutores.Columns[4].HeaderText = "NACIONALIDAD";
        }

        private void Listado_autores(string cTexto)
        {
            AutorBL autorBL = new AutorBL();
            dgvAutores.DataSource = autorBL.ObtenerListadoAutores(cTexto);
            this.Formato_autores();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

        }
    }
}

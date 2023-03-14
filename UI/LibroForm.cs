using BE;
using BL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class LibroForm : Form
    {


        public LibroForm()
        {
            InitializeComponent();
        }
        int nEstadoGuarda = 0;
        string vCodigo;
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_isbn.Text == string.Empty ||
               txt_titulo.Text == string.Empty ||
               cmbEditorial.Text == string.Empty ||
               cmbGenero.Text == string.Empty ||
               txt_edicion.Text == string.Empty) //Validar que todo los datos esten correctos
            {
                MessageBox.Show("Falta ingresar datos requeridos",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else //Procedo a guardar la informacion
            {
                string Rpta = "";
                LibroBE libroBE = new LibroBE();

                libroBE.ISBN = this.vCodigo;
                libroBE.Titulo = txt_titulo.Text;
                libroBE.Edicion = int.Parse(txt_edicion.Text);
                libroBE.Genero = Convert.ToInt32(cmbGenero.SelectedValue);
                libroBE.Editorial = Convert.ToInt32(cmbEditorial.SelectedValue);
                LibroBL libroBL = new LibroBL();


                this.Listado_libros("%");
                MessageBox.Show("!Nuevo Libro registrado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void CagarGenero()
        {
            LibroBL libroBL = new LibroBL();
            cmbGenero.DataSource = libroBL.ObtenerListadoGeneros();
            cmbGenero.ValueMember = "ID";
            cmbGenero.DisplayMember = "Descripcion";
        }

        private void CagarEditorial()
        {
            LibroBL libroBL = new LibroBL();
            cmbEditorial.DataSource = libroBL.ObtenerListadoEditorial();
            cmbEditorial.ValueMember = "ID";
            cmbEditorial.DisplayMember = "Descripcion";
        }

        private void LibroForm_Load(object sender, EventArgs e)
        {
            this.CagarGenero();
            this.CagarEditorial();
            this.Listado_libros("%");
        }
        private void Formato_libros()
        {
            dgvLibros.Columns[0].Width = 100;
            dgvLibros.Columns[0].HeaderText = "ISBN";
            dgvLibros.Columns[1].Width = 145;
            dgvLibros.Columns[1].HeaderText = "TITULO";
            dgvLibros.Columns[2].Width = 55;
            dgvLibros.Columns[2].HeaderText = "EDICION";
            dgvLibros.Columns[3].Width = 100;
            dgvLibros.Columns[3].HeaderText = "GENERO";
            dgvLibros.Columns[4].Width = 100;
            dgvLibros.Columns[4].HeaderText = "EDITORIAL";
        }

        private void Listado_libros(string cTexto)
        {
            LibroBL libroBL = new LibroBL();
            dgvLibros.DataSource = libroBL.ObtenerListadoLibros(cTexto);
            this.Formato_libros();
        }
        private void Selecciona_Item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvLibros.CurrentRow.Cells["ISBN"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                this.vCodigo = Convert.ToString(dgvLibros.CurrentRow.Cells["ISBN"].Value);
                txt_titulo.Text = Convert.ToString(dgvLibros.CurrentRow.Cells["Titulo"].Value);
                txt_edicion.Text = Convert.ToString(dgvLibros.CurrentRow.Cells["Edicion"].Value);
            }
        }
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.nEstadoGuarda = 2;//actualizar registro
            txt_isbn.Select();
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item();
        }
    }
}

using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void menuAutor_Click(object sender, EventArgs e)
        {
            AutorForm form = new AutorForm();
            form.ShowDialog();
        }

        private void libroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroForm form = new LibroForm();
            form.ShowDialog();
        }
    }
}

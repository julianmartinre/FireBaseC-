using ejemplo.firebase.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplo.firebase.ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario c = new Usuario()
            {
                Username = textBox1.Text,
                Password = textBox2.Text
            };
            new ContextoFirebase().Guardar(c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<Usuario> users = new ContextoFirebase().ObtenerTodos();
        }
    }
}

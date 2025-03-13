using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FJ25_T2Ejemplo1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // id, nombre completo, edad, sexo, dirección, fecha nacimiento

        public static List<string[]> personas = new List<string[]> {
            new string[] {"1", "Juan Perez", "25", "M", "Calle 1", "01/01/1990"},
            new string[] {"2", "Maria Lopez", "30", "F", "Calle 2", "01/01/1985"},
            new string[] {"3", "Pedro Ramirez", "35", "M", "Calle 3", "01/01/1980"},
            new string[] {"4", "Ana Rodriguez", "40", "F", "Calle 4", "01/01/1975"},
            new string[] {"5", "Jose Gomez", "45", "M", "Calle 5", "01/01/1970"},
            new string[] {"6", "Laura Suarez", "50", "F", "Calle 6", "03/03/1965"}
        };
 

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string[] persona in personas)
                lbNombres.Items.Add(persona[1]);
        }

        private void lbNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbNombres.SelectedIndex;
            lblNombre.Text = "Nombre: " + personas[index][1];
            lblEdad.Text = "Edad: " + personas[index][2];
            lblSexo.Text = "Sexo: " + personas[index][3];
            lblDireccion.Text = "Dirección: " + personas[index][4];
            lblFNacimiento.Text = "Fecha Nacimiento: " + personas[index][5];
            //pbFoto.Image = (Image)Properties.Resources.ResourceManager.GetObject(personas[index][0]);
            cargarImagen(personas[index][0]);
        }

        public void cargarImagen(string index) {
            string carpeta = Path.Combine(Application.StartupPath, "Fotos");
            string[] formatos = new string[] { ".jpeg", ".jpg", ".png" };
            string rutaImagen = null;
            foreach (string formato in formatos) { 
                string archivo = Path.Combine(carpeta, index + formato);
                if (File.Exists(archivo)) {
                    rutaImagen = archivo;
                    break;
                }
            }
            if (rutaImagen != null)
                pbFoto.Image = new Bitmap(rutaImagen);
            else
                pbFoto.Image = null;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

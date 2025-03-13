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
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static string[] nuevaPersona;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            nuevaPersona = new string[] { 
                (Form1.personas.Count + 1).ToString(),
                tbNombre.Text,
                numEdad.Value.ToString(),
                rbHombre.Checked ? "H" : "M",
                tbDomicilio.Text,
                tpFechaNacimiento.Value.ToShortDateString()
            };

            Form1.personas.Add(nuevaPersona);

            Form1.lbNombres.Items.Add(nuevaPersona[1]);

            guardarFoto(nuevaFoto.FileName);
        }

        public static OpenFileDialog nuevaFoto;
        private void pbFotoNueva_Click(object sender, EventArgs e)
        {
            nuevaFoto = new OpenFileDialog
            {
                Filter = "Imagenes |*.jpg; *.png"
            };

            if (nuevaFoto.ShowDialog() == DialogResult.OK)
            { 
                pbFotoNueva.Image = new Bitmap(nuevaFoto.FileName);
            }
        }

        private void guardarFoto(string archivo) {
            string carpeta = Path.Combine(Application.StartupPath, "Fotos");
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string extension = Path.GetExtension(archivo);
            string destino = Path.Combine(carpeta, nuevaPersona[0] + extension);

            File.Copy(archivo, destino, true);
        }
    }
}

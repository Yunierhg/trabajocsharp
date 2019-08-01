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

namespace prueba_lector_huellas_2
{
    public partial class Form1 : Form
    {
        private DPFP.Template Template;
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnrollButton_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.OnTemplate += this.OnTemplate;
            registro.ShowDialog();
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            Verificacion verificacion = new Verificacion();
            verificacion.Verify(Template);
        }


        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Action(delegate () {
                Template = template;
                VerifyButton.Enabled = SaveButton.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("La huella esta lista para ferificarse.", "Fingerprint Enrollment");
                }
                else
                {
                    MessageBox.Show("El registro de huella no es valido. repita el registro.", "Fingerprint Enrollment");
                }
            }));
        }

       

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Open(save.FileName, FileMode.Create, FileAccess.Write))
                {
                    Template.Serialize(fs);
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(open.FileName))
                {
                    DPFP.Template template = new DPFP.Template(fs);
                    OnTemplate(template);
                }
            }
        }
    }
}

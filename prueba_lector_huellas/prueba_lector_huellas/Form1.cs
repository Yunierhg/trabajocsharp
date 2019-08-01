using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using prueba_lector_huellas.Clases;

namespace prueba_lector_huellas
{
    public partial class Form1 : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Template Template;

        Capturador capturador = new Capturador();

        public Form1()
        {
            InitializeComponent();
        }


        private void btn_captura_Click(object sender, EventArgs e)
        {
            
            lblRespuesta.Text = "Inicia captura";
            capturador.Init_captura(this);
            capturador.iniciar_captura();
        }

        protected virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(capturador.ConvertSampleToBitmap(Sample));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            ImgHuella.Invoke(new Action(()=> ImgHuella.Image = new Bitmap(bitmap, ImgHuella.Size)));
        }



        #region EventHandler funciones
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            
            lblRespuesta.Invoke(new Action(() => lblRespuesta.Text = "La muestra fue capturada"));
            lbl_mensaje.Invoke(new Action(() => lbl_mensaje.Text = "Escanee la huella otra vez"));
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            lbl_mensaje.Invoke(new Action(() => lbl_mensaje.Text = "El dedo se quito del lector"));
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            //lbl_mensaje.Text = "El lector se activa con un toque";
            lbl_mensaje.Invoke(new Action(() => lbl_mensaje.Text = "El lector se activa con un toque"));
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            //lbl_mensaje.Text = "El lector se conecto";
            lbl_mensaje.Invoke(new Action(() => lbl_mensaje.Text = "El lector se conecto"));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            //lbl_mensaje.Text = "El lector se desconecto";
            lbl_mensaje.Invoke(new Action(() => lbl_mensaje.Text = "El lector se desconecto"));
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            //throw new NotImplementedException();
            if(CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                //lblRespuesta.Text = "La calidad de la lectura es buena";
                lbl_mensaje_2.Invoke(new Action(() => lbl_mensaje_2.Text = "La calidad de la lectura es buena"));
            }
            else
            {
                //lblRespuesta.Text = "La calidad de la lectura es mala";
                lbl_mensaje_2.Invoke(new Action(() => lbl_mensaje_2.Text = "La calidad de la lectura es mala"));
            }
        }
        #endregion


        private void registrarHuellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarForm registrar = new RegistrarForm();
            registrar.Show();

            
            //registrar.ShowDialog();
            //this.Close();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Action(() => {
                Template = template;
                //VerifyButton.Enabled = SaveButton.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                }
            }));
        }
    }
}

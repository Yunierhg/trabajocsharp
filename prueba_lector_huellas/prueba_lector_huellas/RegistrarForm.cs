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
    public partial class RegistrarForm : Form, DPFP.Capture.EventHandler
    {
        string log = "";

        private DPFP.Processing.Enrollment Enroller;
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        Capturador capturador = new Capturador();

        public RegistrarForm()
        {
            InitializeComponent();
        }

        public void Init_registro()
        {
            capturador.Init_captura(this);

            Enroller = new DPFP.Processing.Enrollment();            // Create an enrollment.
            UpdateStatus();
        }

        private void DrawPicture(Bitmap bitmap)
        {
            img_huella.Invoke(new Action(() => img_huella.Image = new Bitmap(bitmap, img_huella.Size)));
        }

        /// <summary>
        /// Esto es para ver los resultados de la lectura
        /// </summary>
        private void UpdateStatus()
        {
            txt_estado.Invoke(new Action(() =>
            {
                log += String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded) + "\n";
                txt_estado.Text = log;
            }));
        }

        private void estado(string msj)
        {
            txt_estado.Invoke(new Action(() =>
            {
                log += msj + "\n";
                txt_estado.Text = log;
            }));
        }

        public void Process(DPFP.Sample Sample)
        {
            capturador.Process(Sample);

            DPFP.FeatureSet features = capturador.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            if (features != null)
            {
                try
                {
                    Enroller.AddFeatures(features);		// Add feature set to template.
                }
                finally
                {
                    DrawPicture(capturador.ConvertSampleToBitmap(Sample));
                    UpdateStatus();
                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            //OnTemplate(Enroller.Template);
                            //SetPrompt("Click Close, and then click Fingerprint Verification.");
                            estado("Click Close, and then click Fingerprint Verification.");
                            capturador.deter_captura();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            capturador.deter_captura();
                            UpdateStatus();
                            OnTemplate(null);
                            capturador.iniciar_captura();
                            break;
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Init_registro();
            capturador.iniciar_captura();
        }

        


        #region EventHandler funciones
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            //throw new NotImplementedException();
            Process(Sample);
            //estado("Click Close, and then click Fingerprint Verification.");
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            estado("El dedo se quito del lector");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            estado("El lector se activa con un toque");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            estado("El lector se conecto");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
            estado("El lector se desconecto");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            //throw new NotImplementedException();
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                //lblRespuesta.Text = "La calidad de la lectura es buena";
                //lbl_mensaje_2.Invoke(new Action(() => lbl_mensaje_2.Text = "La calidad de la lectura es buena"));
                estado("La calidad de la lectura es buena");
            }
            else
            {
                //lblRespuesta.Text = "La calidad de la lectura es mala";
                //lbl_mensaje_2.Invoke(new Action(() => lbl_mensaje_2.Text = "La calidad de la lectura es mala"));
                estado("La calidad de la lectura es mala");
            }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            capturador.deter_captura();
            this.Close();
        }


    }
}

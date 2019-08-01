using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_lector_huellas
{
    class Capturador
    {
        private DPFP.Capture.Capture capturador;

        public void Init_captura(DPFP.Capture.EventHandler handler)
        {
            try
            {
                capturador = new DPFP.Capture.Capture();
                if(capturador != null)
                {
                    capturador.EventHandler = handler;
                    //return "exito";
                }
                else
                {
                    //return "no se pudo inicializar la captura";
                    MessageBox.Show("no se pudo inicializar la captura", "Error", MessageBoxButtons.OK);
                }
            }
            catch
            {
                //return "Catch";
                MessageBox.Show("Catch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void iniciar_captura()
        {
            if(capturador != null)
            {
                try
                {
                    capturador.StartCapture();
                }
                catch
                {
                    MessageBox.Show("no se pudo iniciar la captura", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Captura no inicializada", "Error", MessageBoxButtons.OK);
            }
        }

        public void deter_captura()
        {
            if (capturador != null)
            {
                try
                {
                    capturador.StopCapture();
                }
                catch
                {
                    MessageBox.Show("no se pudo detener la captura", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Captura no inicializada", "Error", MessageBoxButtons.OK);
            }
        }

        public virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            /*this.Invoke(new Function(delegate () {
                Picture.Image = new Bitmap(bitmap, Picture.Size);   // fit the image into the picture box
            }));*/
        }

        public Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }

        public DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
    }
}

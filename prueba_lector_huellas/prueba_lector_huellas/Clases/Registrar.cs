using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_lector_huellas.Clases
{
    class Registrar
    {
        private DPFP.Processing.Enrollment Enroller;
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        Capturador capturador = new Capturador();

        public void Init_registro(DPFP.Capture.EventHandler handler)
        {
            capturador.Init_captura(handler);

            Enroller = new DPFP.Processing.Enrollment();            // Create an enrollment.
            //UpdateStatus();
        }

        /// <summary>
        /// Esto es para ver los resultados de la lectura
        /// </summary>
        private string UpdateStatus()
        {
            // Show number of samples needed.
            //SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
            return Enroller.FeaturesNeeded.ToString();

        }

        public void Process(DPFP.Sample Sample)
        {
            capturador.Process(Sample);

            DPFP.FeatureSet features = capturador.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            if(features != null)
            {
                try
                {
                    Enroller.AddFeatures(features);		// Add feature set to template.
                }
                finally
                {
                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            OnTemplate(Enroller.Template);
                            //SetPrompt("Click Close, and then click Fingerprint Verification.");
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
    }
}

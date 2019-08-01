using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_lector_huellas_2
{
    class Verificacion:Captura
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;

        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Verificacion";
            Verificator = new DPFP.Verification.Verification();     // Create a fingerprint template verificator
            UpdateStatus(0);
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
            {
                // Compare the feature set with our template
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                Verificator.Verify(features, Template, ref result);
                UpdateStatus(result.FARAchieved);
                if (result.Verified)
                {
                    MakeReport("Lectura verificada.");
                }
                else
                {
                    MakeReport("Lectura no verificada.");
                }
            }
        }

        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("Tasa de aceptacion false (FAR) = {0}", FAR));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maqueta_efedoc1.Classes
{
    public class alertaItems
    {
        public string nombre { get; private set; }
        public string diagnostico { get; private set; }
        public string tipoLectura { get; private set; }
        public double lectura { get; private set; }
        public string um { get; private set; }

        public alertaItems(string Nombre, string Diagnostico, double Lectura, string TipoLectura, string Um)
        {
            nombre = Nombre;
            diagnostico = Diagnostico;
            lectura = Lectura;
            tipoLectura = TipoLectura;
            um = Um;
        }
    }
}

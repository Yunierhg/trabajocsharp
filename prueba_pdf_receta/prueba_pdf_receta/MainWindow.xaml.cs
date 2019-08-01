using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prueba_pdf_receta
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PdfReceta pdf = new PdfReceta();
            pdf.crearPdfReceta("18.536.511-5_22-05-2019");

            wea.Source = new Uri($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Recetas Medicas\\18.536.511-5_22-05-2019.pdf");
        }
    }
}

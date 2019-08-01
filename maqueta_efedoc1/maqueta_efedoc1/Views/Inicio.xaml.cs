using maqueta_efedoc1.Classes;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace maqueta_efedoc1.Views
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();


            List<menuItems> menu = new List<menuItems>();

            menu.Add(new menuItems("Inicio", PackIconKind.Home));
            menu.Add(new menuItems("Pacientes", PackIconKind.AccountMultiple));
            menu.Add(new menuItems("Historial", PackIconKind.ClipboardText));
            menu.Add(new menuItems("Medicamentos", PackIconKind.Store));

            ListViewMenu.ItemsSource = menu;

            PacientesGrafico diabeticos = new PacientesGrafico("Pacientes diabeticos", 47);
            PacientesGrafico hipertensos = new PacientesGrafico("Pacientes Hipertensos", 53);

            List<PacientesGrafico> ppacientes = new List<PacientesGrafico>();
            List<PacientesGrafico> ppacientes2 = new List<PacientesGrafico>();
            ppacientes.Add(diabeticos);
            ppacientes2.Add(hipertensos);

            DataContext = new PacientesGraficoModel(ppacientes, ppacientes2);


            List<alertaItems> alertas = new List<alertaItems>();

            alertas.Add(new alertaItems("Yunier Hernandez", "Hipertensión Arterial", 140.0, "Presión Arterial", "mmhg"));
            alertas.Add(new alertaItems("Hugo Garcia", "hiperglucemia", 150.0, "Glicemia", "mg/dl"));
            alertas.Add(new alertaItems("Carlos Sánchez", "hipoglicemia ", 60.0, "Glicemia", "mg/dl"));

            alertas.Add(new alertaItems("Roberto Perez", "Hipertensión Arterial", 140.0, "Presión Arterial", "mmhg"));
            alertas.Add(new alertaItems("Gaston Juvenal", "hiperglucemia", 150.0, "Glicemia", "mg/dl"));
            alertas.Add(new alertaItems("Mauricio Herrera", "hipoglicemia ", 60.0, "Glicemia", "mg/dl"));

            ListViewAlertas.ItemsSource = alertas;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

    }

    internal class PacientesGrafico
    {
        public string Titulo { get; private set; }
        public int Porcentage { get; private set; }
        public PacientesGrafico(string titulo, int porcentage)
        {
            Titulo = titulo;
            Porcentage = porcentage;
        }
    }

    internal class PacientesGraficoModel
    {
        public List<PacientesGrafico> Pacientes { get; private set; }
        public List<PacientesGrafico> Pacientes2 { get; private set; }

        public PacientesGraficoModel(List<PacientesGrafico> pacientes, List<PacientesGrafico> pacientes2)
        {
            Pacientes = pacientes;
            Pacientes2 = pacientes2;
        }
    }

}

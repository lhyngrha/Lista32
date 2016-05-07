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

namespace Lista3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CadCursosClick(object sender, RoutedEventArgs e)
        {
            CadastroCurso x = new CadastroCurso();
            x.Show();
        }

        private void CadDisiciplinaClick(object sender, RoutedEventArgs e)
        {
            CadastroDisciplina x = new CadastroDisciplina();
            x.Show();
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {

        }

        private void ConsCursosClick(object sender, RoutedEventArgs e)
        {

        }

        private void ConsAlunosClick(object sender, RoutedEventArgs e)
        {

        }

        private void ConsDisciplinasClick(object sender, RoutedEventArgs e)
        {

        }

        private void CadAlunoClick(object sender, RoutedEventArgs e)
        {
            CadAluno x = new CadAluno();
            x.Show();
        }

        private void CadNotaClick(object sender, RoutedEventArgs e)
        {
            CadNota x = new CadNota();
            x.Show();
        }
    }
}

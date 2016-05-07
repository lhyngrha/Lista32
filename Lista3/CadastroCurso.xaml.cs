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

namespace Lista3
{
    /// <summary>
    /// Interaction logic for CadastroCurso.xaml
    /// </summary>
    public partial class CadastroCurso : Window
    {
        public CadastroCurso()
        {
            InitializeComponent();
        }

        private DataBaseDataContext dc = new DataBaseDataContext();

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var x = from f in dc.Cursos select new { f.id, f.descricao };
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = x.ToList();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Curso c = new Curso();
            c.id = int.Parse(txtId.Text);
            c.descricao = txtDescricao.Text;
            dc.Cursos.InsertOnSubmit(c);
            dc.SubmitChanges();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Curso c = (from f in dc.Cursos where f.id == int.Parse(txtId.Text) select f).Single();
            c.descricao = txtDescricao.Text;
            dc.SubmitChanges();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Curso c = (from f in dc.Cursos where f.id == int.Parse(txtId.Text) select f).Single();
            dc.Cursos.DeleteOnSubmit(c);
            dc.SubmitChanges();
        }
    }
}

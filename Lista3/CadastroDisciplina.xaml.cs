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
    /// Interaction logic for CadastroDisciplina.xaml
    /// </summary>
    public partial class CadastroDisciplina : Window
    {
        public CadastroDisciplina()
        {
            InitializeComponent();
        }

        private DiagramasDataContext dc = new DiagramasDataContext();

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Disciplina x = new Disciplina();
            x.id = int.Parse(txtId.Text);
            x.descricao = txtDesc.Text;
            dc.Disciplinas.InsertOnSubmit(x);
            dc.SubmitChanges();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Disciplina c = (from f in dc.Disciplinas where f.id == int.Parse(txtId.Text) select f).Single();
            c.descricao = txtDesc.Text;
            dc.SubmitChanges(); 
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Disciplina c = (from f in dc.Disciplinas where f.id == int.Parse(txtId.Text) select f).Single();
            dc.Disciplinas.DeleteOnSubmit(c);
            dc.SubmitChanges();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var x = from f in dc.Disciplinas select new { f.id, f.descricao };
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = x.ToList();

        }
    }
}

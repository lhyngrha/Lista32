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
    /// Interaction logic for CadAluno.xaml
    /// </summary>
    public partial class CadAluno : Window
    {
        public CadAluno()
        {
            InitializeComponent();
        }

        private DataBaseDataContext dc = new DataBaseDataContext();

        private void selectCursos()
        {
            var r = from f in dc.Cursos orderby f.descricao select f;
            comboBox.ItemsSource = r.ToList();
            comboBox.SelectedValuePath = "id";
            comboBox.DisplayMemberPath = "descricao";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Aluno a = new Aluno();
            a.id = int.Parse(txtId.Text);
            a.nome = txtNome.Text;
            a.email = txtEmail.Text;
            a.fone = txtFone.Text;
            a.nascimento = data.SelectedDate;
            a.idCurso = (int)comboBox.SelectedValue;
            dc.Alunos.InsertOnSubmit(a);
            dc.SubmitChanges();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Aluno a = (from f in dc.Alunos where f.id == int.Parse(txtId.Text) select f).Single();

            a.nome = txtNome.Text;
            a.email = txtEmail.Text;
            a.fone = txtFone.Text;
            a.nascimento = data.SelectedDate;
            dc.SubmitChanges();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            selectCursos();
            data.SelectedDate = DateTime.Now;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Aluno a = (from f in dc.Alunos where f.id == int.Parse(txtId.Text) select f).Single();
            dc.Alunos.DeleteOnSubmit(a);
            dc.SubmitChanges();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var r = from f in dc.Alunos select new {f.id, f.nome, f.email, f.fone, f.nascimento, f.idCurso};
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = r.ToList();
        }
    }
}

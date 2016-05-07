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
    /// Interaction logic for CadNota.xaml
    /// </summary>
    public partial class CadNota : Window
    {
        public CadNota()
        {
            InitializeComponent();
        }

        private DataBaseDataContext dc = new DataBaseDataContext();

        private void Window_Activated(object sender, EventArgs e)
        {
            selectAlunos();
            selectDisciplinas();
        }

        private void selectDisciplinas()
        {
            var r = from f in dc.Disciplinas orderby f.descricao select f;
            cbDisciplina.ItemsSource = r.ToList();
            cbDisciplina.SelectedValuePath = "id";
            cbDisciplina.DisplayMemberPath = "descricao";
        }

        private void selectAlunos()
        {
            var r = from f in dc.Alunos orderby f.nome select f;
            cbAluno.ItemsSource = r.ToList();
            cbAluno.SelectedValuePath = "id";
            cbAluno.DisplayMemberPath = "nome";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Boletim b = new Boletim();
            b.ano = DateTime.Now.Year;
            b.idAluno = (int)cbAluno.SelectedValue;
            b.idDisciplina = (int)cbDisciplina.SelectedValue;
            b.nota1 = int.Parse(txtN1.Text);
            b.nota2 = int.Parse(txtN2.Text);
            b.nota3 = int.Parse(txtN3.Text);
            b.nota4 = int.Parse(txtN4.Text);
            b.mediaParcial = (b.nota4 + b.nota3 + b.nota2 + b.nota1) / 4;
            if (b.mediaParcial < 6)
            {
                b.notaFinal = int.Parse(txtNotaFinal.Text);
                b.mediaFinal = (b.notaFinal + b.mediaParcial) / 2;
            }

            else b.mediaFinal = b.mediaParcial;
        }

        private void btnSelectAluno_Click(object sender, RoutedEventArgs e)
        {
            Boletim b = (from f in dc.Boletims where f.idAluno == (int)cbAluno.SelectedValue select f).Single();
            txtN1.Text = b.nota1.ToString();
            txtN2.Text = b.nota2.ToString();
            txtN3.Text = b.nota3.ToString();
            txtN4.Text = b.nota4.ToString();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Boletim b = (from f in dc.Boletims where f.idAluno == (int)cbAluno.SelectedValue select f).Single();
            b.nota1 = int.Parse(txtN1.Text);
            b.nota2 = int.Parse(txtN2.Text);
            b.nota3 = int.Parse(txtN3.Text);
            b.nota4 = int.Parse(txtN4.Text);
            b.notaFinal = int.Parse(txtNotaFinal.Text);
            dc.SubmitChanges();
        }
    }
}

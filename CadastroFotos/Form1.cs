using CadastroFotos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroFotos
{
    public partial class Form1 : Form
    {
        private MyDbContext context;
        int id = 0;
        public Form1()
        {
            InitializeComponent();
            context = new MyDbContext();
            refreshGrid();
        }

        private void refreshGrid()
        {
            BindingSource bi = new BindingSource();


            var query = from t in context.Alunos
                        orderby t.Id 
                        select new { t.Id, t.Nome, t.Foto };

            bi.DataSource = query.ToList();

            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (picBoxImg.Image != null)
            {
               
                string fotoNome = "img_"+id+".jpg";
                string folder = @"C:\Users\Francisca\source\repos\Files";
                string pathstring = Path.Combine(folder, fotoNome);
                Image a = picBoxImg.Image;
                a.Save(pathstring);


                var newAluno = new Model.Aluno
                {
                    
                    Nome = txtNome.Text,
                    Foto = pathstring

                };

                context.Alunos.Add(newAluno);
                context.SaveChanges();
                refreshGrid();



            }
            else
            {
                MessageBox.Show("É nessario incluir uma imagem");
            }
            id++;
        }

        private void picBoxImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                open.Filter = "(*.jpg;*.jpeg;*.bmp;) | *.jpg; *.jpeg; *.bmp;";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);
                }

            }
        }
    }
}

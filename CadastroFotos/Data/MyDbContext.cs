using CadastroFotos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFotos.Data
{
    class MyDbContext: DbContext
    {

        public DbSet<Aluno> Alunos { get; set; }
    }
}

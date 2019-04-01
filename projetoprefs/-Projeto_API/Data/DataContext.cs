using System.Collections.Generic;
using _Projeto_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _Projeto_API.Data
{
    //classe para gerenciar o banco de dados
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){ }

        public DbSet<Funcionario> Funcionarios {get ; set ;}


          protected override void OnModelCreating(ModelBuilder builder)
          {
              builder.Entity<Funcionario>().HasData(
                new List<Funcionario>(){
                    new Funcionario(){
                        Id = 1 ,
                        Nome = "Camila",
                        Idade = 24,
                        DataNascimento = "20/06/1994",
                        Funcao = "Estagiária nível 1"  
                    },
                    new Funcionario(){
                        Id = 2 ,
                        Nome = "Gustavo",
                        Idade = 22,
                        DataNascimento = "26/06/1996",
                        Funcao = "Estagiário nível 2"  
                    },
                     new Funcionario(){
                        Id = 3 ,
                        Nome = "Livia",
                        Idade = 28,
                        DataNascimento = "14/09/1991",
                        Funcao = "Estagiária nível 1"  
                    }
                }
              );
          }


    }
}
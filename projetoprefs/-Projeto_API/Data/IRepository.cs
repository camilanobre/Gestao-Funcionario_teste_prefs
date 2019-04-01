using System.Threading.Tasks;
using _Projeto_API.Models;

namespace _Projeto_API.Data
{
    public interface IRepository
    {
         //metodos gerais, criando de forma genérica
         void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        Task<bool> SaveChangesAsync();

        //FUNCIONARIO
        
       Task <Funcionario[]> GetAllFuncionariosAsync();
       Task<Funcionario> GetFuncionariosAsyncById (int FuncionarioId);
    }
}
using System.Linq;
using System.Threading.Tasks;
using _Projeto_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _Projeto_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;

        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


        //FUNCIONARIOS
        public async Task<Funcionario[]> GetAllFuncionariosAsync()
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            query = query
            .AsNoTracking()
            .OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }


        public async Task<Funcionario> GetFuncionariosAsyncById(int FuncionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            query = query
            .AsNoTracking()
            .OrderBy(f => f.Id)
            .Where(funcionario => funcionario.Id == FuncionarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
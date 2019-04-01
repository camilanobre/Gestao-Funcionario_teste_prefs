using System.Threading.Tasks;
using _Projeto_API.Data;
using _Projeto_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _Projeto_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        public IRepository _repo { get; }
        public FuncionarioController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllFuncionariosAsync();

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult> GetByFuncionarioId(int FuncionarioId)
        {
            try
            {
                var result = await _repo.GetFuncionariosAsyncById(FuncionarioId);

                return Ok(result);
                
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }


        [HttpPost]
        public async Task <IActionResult> post(Funcionario model)
        {
            try
            {

                _repo.Add(model);

                if( await _repo.SaveChangesAsync())
                {
                    return Created($"/api/funcionario/{model.Id}", model);
                 }

                 return BadRequest();

                
                
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpPut("{FuncionarioId}")]
        public async Task <IActionResult> put(int FuncionarioId, Funcionario model)
        {
            try
            {

                var funcionario = await _repo.GetFuncionariosAsyncById(FuncionarioId);
                if (funcionario == null) return NotFound();
               
                _repo.Update(model);
                
                if( await _repo.SaveChangesAsync())
                {
                   //funcionario = await _repo.GetFuncionariosAsyncById(FuncionarioId);

                    return Created($"/api/funcionario/{model.Id}", funcionario);
                 }


            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
             return BadRequest();
        }

        [HttpDelete("{FuncionarioId}")]
        public async Task <IActionResult> delete( int FuncionarioId)
        {
            try
            {
                var funcionario = await _repo.GetFuncionariosAsyncById(FuncionarioId);
                if (funcionario == null) return NotFound();
               
                 _repo.Delete(funcionario);
                
                if( await _repo.SaveChangesAsync())
                {
                return Ok();
            }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
             return BadRequest();

        }
    }
}
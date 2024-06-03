using Microsoft.AspNetCore.Mvc;
using TaskHelper.Context;
using TaskHelper.Models;

namespace TaskHelper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterTodasTarefas()
        {
            var tarefas = _context.Tarefas;
            return Ok(tarefas);
        }

        [HttpGet("OpterPorId")]
        public IActionResult ObterPeloId(int Id)
        {
            var tarefa = _context.Tarefas.Find(Id);

            if(tarefa == null) return NotFound();


            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok();
        }
    }
}

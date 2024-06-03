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

        [HttpGet("{Id}")]
        public IActionResult ObterPeloId(int Id)
        {
            var tarefa = _context.Tarefas.Find(Id);

            if(tarefa == null) return NotFound();


            return Ok(tarefa);
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarPeloId(int Id,Tarefa tarefaAtualizada)
        {
            var tarefa = _context.Tarefas.Find(Id);

            if (tarefa == null) return NotFound();

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Status = tarefaAtualizada.Status;

            _context.Update(tarefa);
            _context.SaveChanges();

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

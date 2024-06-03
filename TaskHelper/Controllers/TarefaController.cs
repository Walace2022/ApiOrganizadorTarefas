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

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo) 
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

            if (tarefas.Count() == 0) return NotFound("Nenhuma tarefa encontrada.");

            return Ok(tarefas);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefas = _context.Tarefas.Where(x => x.Data.Date == data.Date);

            if (tarefas.Count() == 0) return NotFound("Nenhuma tarefa encontrada.");

            return Ok(tarefas);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorData(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status);

            if (tarefas.Count() == 0) return NotFound("Nenhuma tarefa encontrada.");

            return Ok(tarefas);
        }

        [HttpGet("{Id}")]
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

        [HttpDelete("{Id}")]
        public IActionResult DeletarPeloId(int Id)
        {
            var tarefa = _context.Tarefas.Find(Id);

            if (tarefa == null) return NotFound();

            _context.Remove(tarefa);
            _context.SaveChanges();

            return Ok();
        }

    }
}

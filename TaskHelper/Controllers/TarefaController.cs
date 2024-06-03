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

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok();
        }
    }
}

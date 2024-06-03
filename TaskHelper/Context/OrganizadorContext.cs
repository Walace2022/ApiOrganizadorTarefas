using Microsoft.EntityFrameworkCore;
using TaskHelper.Models;

namespace TaskHelper.Context;
public class OrganizadorContext : DbContext
{
    public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas { get; set; }
}

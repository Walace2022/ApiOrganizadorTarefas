namespace TaskHelper.Models;
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime data { get; set; }
    public int MyProperty { get; set; }
    public EnumStatusTarefa Status { get; set; }
}

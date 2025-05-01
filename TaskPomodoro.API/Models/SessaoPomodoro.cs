namespace TaskPomodoro.API.Models
{
    public class SessaoPomodoro
    {
        public int Id { get; set; }
        public int? TarefaId { get; set; }
        public Tarefa? Tarefa { get; set; }
        public DateTime Inicio { get; set; } = DateTime.UtcNow;
        public DateTime? Fim { get; set; }
        public string Tipo { get; set; } = "Pomodoro";
        public bool Finalizada { get; set; } = false;
    }
}

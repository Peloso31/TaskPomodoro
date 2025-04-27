namespace TaskPomodoro.API.Models
{
    public class Tarefa
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public bool Concluida { get; set; }
        public int TempoEstimado { get; set; } // em minutos
        public int TempoGasto { get; set; } // em minutos
        public int PomodorosConcluidos { get; set; }
        public int PomodorosRestantes { get; set; }
        public Tarefa()
        {
            DataCriacao = DateTime.Now;
            Concluida = false;
            PomodorosConcluidos = 0;
            PomodorosRestantes = 0;
        }
    }
}

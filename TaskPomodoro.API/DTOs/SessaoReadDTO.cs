using System;

namespace TaskPomodoro.API.DTOs
{
    public class SessaoReadDTO
    {
        public int ID { get; set; }
        public string Tipo { get; set; } = "Pomodoro";
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Concluido { get; set; } = false;
        public int? TarefaID { get; set; }
    }
}

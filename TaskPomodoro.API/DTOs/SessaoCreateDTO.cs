using System;

namespace TaskPomodoro.API.DTOs
{
    public class SessaoCreateDTO
    {
        public int? TarefaID { get; set; }
        public string Tipo { get; set; } = "Pomodoro";
    }
}

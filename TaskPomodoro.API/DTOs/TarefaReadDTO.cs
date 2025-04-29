namespace TaskPomodoro.API.DTOs
{
    public class TarefaReadDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}

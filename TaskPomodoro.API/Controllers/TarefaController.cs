using Microsoft.AspNetCore.Mvc;
using TaskPomodoro.API.Data;
using TaskPomodoro.API.Models;
using TaskPomodoro.API.DTOs;
using AutoMapper;

namespace TaskPomodoro.API.Controllers
{
    // Define que essa classe é um controller de API
    [ApiController]

    // Define a rota base para os endpoints, ex: /api/tarefa
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        // Injeção do DbContext (banco de dados)
        private readonly AppDbContext _context;
        private readonly IMapper _mapper; // Injeção do AutoMapper para mapeamento de DTOs
        public TarefaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: /api/tarefa
        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> GetAll()
        {
            var tarefas = _context.Tarefas.ToList(); // busca todas as tarefas do banco
            return Ok(tarefas); // retorna 200 OK + JSON
        }

        // GET: /api/tarefa/{id}
        [HttpGet("{id}")]
        public ActionResult<Tarefa> GetById(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
                return NotFound(); // 404

            return Ok(tarefa); // 200
        }

        // POST: /api/tarefa
        [HttpPost]
        public ActionResult<Tarefa> Create(TarefaCreateDTO tarefaCreateDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaCreateDTO); // mapeia o DTO para a entidade Tarefa

            _context.Tarefas.Add(tarefa); // adiciona no banco
            _context.SaveChanges();       // salva as mudanças

            var tarefaReadDTO = _mapper.Map<TarefaReadDTO>(tarefa); // mapeia para o DTO

            // retorna 201 Created com a URL para buscar esse recurso
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefaReadDTO);
        }

        // PUT: /api/tarefa/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Tarefa tarefa)
        {
            var tarefaExistente = _context.Tarefas.Find(id);
            if (tarefaExistente == null)
                return NotFound();

            // atualiza os campos permitidos
            tarefaExistente.Nome = tarefa.Nome;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Concluida = tarefa.Concluida;

            _context.SaveChanges();
            return NoContent(); // 204 (sem body)
        }

        // DELETE: /api/tarefa/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return NoContent(); // 204
        }
    }
}

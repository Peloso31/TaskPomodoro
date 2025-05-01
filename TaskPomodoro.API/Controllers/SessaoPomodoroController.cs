using Microsoft.AspNetCore.Mvc;
using TaskPomodoro.API.Data;
using TaskPomodoro.API.DTOs;
using TaskPomodoro.API.Models;
using AutoMapper;

namespace TaskPomodoro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessaoPomodoroController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoPomodoroController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<SessaoReadDTO> IniciarSessao(SessaoCreateDTO dto)
        {
            var sessao = _mapper.Map<SessaoPomodoro>(dto);
            sessao.Inicio = DateTime.UtcNow;
            _context.SessoesPomodoro.Add(sessao);
            _context.SaveChanges();

            var result = _mapper.Map<SessaoReadDTO>(sessao);
            return CreatedAtAction(nameof(ObterPorId), new { id = result.ID }, result);
        }

        [HttpPut("{id}/finalizar")]
        public IActionResult FinalizarSessao(int id)
        {
            var sessao = _context.SessoesPomodoro.Find(id);
            if (sessao == null)
                return NotFound();

            if (sessao.Finalizada)
                return BadRequest("Sessão já finalizada.");

            sessao.Fim = DateTime.UtcNow;
            sessao.Finalizada = true;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SessaoReadDTO>> ObterTodas()
        {
            var sessoes = _context.SessoesPomodoro.ToList();
            var dtos = _mapper.Map<List<SessaoReadDTO>>(sessoes);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<SessaoReadDTO> ObterPorId(int id)
        {
            var sessao = _context.SessoesPomodoro.Find(id);
            if (sessao == null)
                return NotFound();

            var dto = _mapper.Map<SessaoReadDTO>(sessao);
            return Ok(dto);
        }
    }
}

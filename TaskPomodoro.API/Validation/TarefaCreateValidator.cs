using FluentValidation;
using TaskPomodoro.API.DTOs;

namespace TaskPomodoro.API.Validations
{
    public class TarefaCreateValidator : AbstractValidator<TarefaCreateDTO>
    {
        public TarefaCreateValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MinimumLength(3).WithMessage("O título deve ter pelo menos 3 caracteres.");

            RuleFor(x => x.Descricao)
                .MaximumLength(300).WithMessage("A descrição pode ter no máximo 300 caracteres.");
        }
    }
}

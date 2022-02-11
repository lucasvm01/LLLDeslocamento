using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class FinalizarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long deslocamentoId { get; set; }
        public long kmFim { get; set; }
        public string observacao { get; set; }
    }
    public class FinalizarDeslocamentoCommandHandler : IRequestHandler<FinalizarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinalizarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(FinalizarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento
                .FindBy(d => d.Id == request.deslocamentoId)
                .FirstAsync(cancellationToken);

            deslocamento.FinalizarDeslocamento(DateTime.Now,
                                                request.kmFim,
                                                request.observacao);

            await _unitOfWork.CommitAsync();

            return deslocamento;
        }
    }   
}

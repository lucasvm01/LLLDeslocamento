using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.Application.Deslocamentos.Queries
{
    public class GetDeslocamentoQuery : IRequest<Deslocamento>
    {
        public long deslocamentoId { get; set; }
    }

    public class GetDeslocamentoQueryHandler : IRequestHandler<GetDeslocamentoQuery, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Deslocamento> Handle(GetDeslocamentoQuery request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento
                .FindBy(d => d.Id == request.deslocamentoId)
                .FirstAsync(cancellationToken);

            return deslocamento;
        }
    }
}

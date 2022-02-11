using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class IniciarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long condutorId { get; set; }
        public long clienteId { get; set; }
        public long veiculoId { get; set; }

        public long kmInicio { get; set; }
    }

    public class IniciarDeslocamentoCommandHandler : IRequestHandler<IniciarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IniciarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(IniciarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var deslocamentoInsert = new Deslocamento(request.clienteId,
                                                        request.condutorId,
                                                        request.veiculoId,
                                                        DateTime.Now,
                                                        request.kmInicio);

            var repositoryDeslocamento= _unitOfWork.GetRepository<Deslocamento>();

            repositoryDeslocamento.Add(deslocamentoInsert);

            await _unitOfWork.CommitAsync();

            return deslocamentoInsert;
        }
    }
}



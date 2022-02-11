using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;

namespace AppDeslocamento.Application.Veiculos.Commands
{
    public class CadastrarVeiculoCommand : IRequest<Veiculo>
    {
        public string placa { get; set; }
        public string descricao { get; set; }
    }

    public class CadastrarVeiculoCommandHandler : IRequestHandler<CadastrarVeiculoCommand, Veiculo>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CadastrarVeiculoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Veiculo> Handle(CadastrarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculoInsert = new Veiculo(request.placa, request.descricao);

            var repositoryVeiculo = _unitOfWork.GetRepository<Veiculo>();

            repositoryVeiculo.Add(veiculoInsert);

            await _unitOfWork.CommitAsync();

            return veiculoInsert;
        }
    }
}

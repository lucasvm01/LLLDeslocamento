using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.Application.Veiculos.Queries
{
    public class GetVeiculosQuery : IRequest<List<Veiculo>>
    {
    }

    public class GetVeiculoQueryHandler : IRequestHandler<GetVeiculosQuery, List<Veiculo>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetVeiculoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Veiculo>> Handle(GetVeiculosQuery request, CancellationToken cancellationToken)
        {
            var repositoryVeiculo =
                _unitOfWork.GetRepository<Veiculo>();

            var veiculos = await repositoryVeiculo
                .GetAll()
                .ToListAsync(cancellationToken);

            return veiculos;
        }
    }
}

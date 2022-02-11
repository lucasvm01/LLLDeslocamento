using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.Application.Deslocamentos.Queries
{
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {

    }
    public class GetDeslocamentosQueryHandler : IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamento>> Handle(GetDeslocamentosQuery request, CancellationToken cancellationToken)
        {
            var deslocamentoRepository = 
                _unitOfWork.GetRepository<Deslocamento>();

            var deslocamentos = await deslocamentoRepository
                .GetAll()
                .ToListAsync();

            return deslocamentos;
        }
    }
}

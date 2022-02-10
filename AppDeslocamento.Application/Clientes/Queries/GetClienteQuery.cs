using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.Application.Clientes.Queries
{
    public class GetClienteQuery : IRequest<Cliente>
    {
        public long clienteId { get; set; }
    }

    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClienteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            var cliente = await repositoryCliente
                .FindBy(c => c.Id == request.clienteId)
                .FirstAsync(cancellationToken);

            return cliente;
        }
    }
}


using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;

namespace AppDeslocamento.Application.Clientes
{
    public class CadastrarClienteCommand : IRequest<Cliente>
    {
        public string nome { get; set; }
        public string cpf { get; set; }
    }

    public class CadastrarClienteCommandHandler : IRequestHandler<CadastrarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Cliente> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteInsert = new Cliente(request.nome, request.cpf);

            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();
    
            repositoryCliente.Add(clienteInsert);

            await _unitOfWork.CommitAsync();

            return clienteInsert;
        }
    }
}


using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;

namespace AppDeslocamento.Application.Clientes
{
    internal class CadastrarClienteCommand : IRequest<Cliente>
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
        public Task<Cliente> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

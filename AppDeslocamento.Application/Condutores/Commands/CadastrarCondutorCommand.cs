using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using MediatR;


namespace AppDeslocamento.Application.Condutores.Commands
{
    public class CadastrarCondutorCommand : IRequest<Condutor>
    {
        public string nome { get; set; }
        public string email { get; set; }
    }

    public class CadastrarCondutorCommandHandler : IRequestHandler<CadastrarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Condutor> Handle(CadastrarCondutorCommand request, CancellationToken cancellationToken)
        {
            var condutorInsert = new Condutor(request.nome, request.email);

            var repositoryCondutor = _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInsert);

            await _unitOfWork.CommitAsync();

            return condutorInsert;
        }
    }
}




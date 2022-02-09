using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string cpf, string nome)
        {
            cpf = cpf;
            nome = nome;
        }

        public Cliente(){

        }
        public string cpf { get; set; }
        public string nome { get; set; }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();

    }

}

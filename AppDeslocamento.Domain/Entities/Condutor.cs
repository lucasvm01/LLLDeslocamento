using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public  class Condutor : BaseEntity
    {
        public Condutor(string nome, string emai)
        {
            nome = nome;
            emai = emai;
        }

        public Condutor()
        {

        }

        public string nome { get; set; }
        public string email { get; set;}

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
    }
}

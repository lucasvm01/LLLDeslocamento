using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public Veiculo(string placa, string descricao)
        {
            this.placa = placa;
            this.descricao = descricao;
        }
        public Veiculo()
        {

        }
        public string placa { get; set; }
        public string descricao { get; set; }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
    }
}

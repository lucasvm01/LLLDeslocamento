using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {
        public Deslocamento(long clienteId, long condutorId, long veiculoId, DateTime dataHoraInicio, long kmInicio)
        {
            this.clienteId = clienteId;
            this.condutorId = condutorId;
            this.veiculoId = veiculoId;
            this.dataHoraInicio = dataHoraInicio;
            this.kmInicio = kmInicio;
            this.observacao = "";
            this.kmFim = 0;
        }
        public Deslocamento()
        {

        }

        public void FinalizarDeslocamento(DateTime dataHoraFim, long kmFim, string observacao)
        {
            this.dataHoraFim = dataHoraFim;
            this.kmFim = kmFim;
            this.observacao = observacao;
        }

        public long clienteId { get; set; }
        public long condutorId { get; set; }
        public long veiculoId { get; set; }

        public DateTime dataHoraInicio { get; set; }
        public DateTime? dataHoraFim { get; set; }
        public long kmInicio { get; set; }
        public long kmFim { get; set; }
        public string observacao { get; set; }


        public Cliente Cliente { get; set; }
        public Condutor Condutor { get; set; }
        public Veiculo Veiculo { get; set; }


    }
}

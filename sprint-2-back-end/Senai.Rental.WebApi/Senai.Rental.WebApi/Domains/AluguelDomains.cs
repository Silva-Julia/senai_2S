using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomains
    {
        public int idAluguel { get; set; }
        public VeiculoDomains Veiculo { get; set; }
        public ClienteDomains Cliente { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
    }
}

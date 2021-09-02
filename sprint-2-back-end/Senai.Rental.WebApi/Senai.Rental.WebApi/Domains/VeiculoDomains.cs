using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomains
    {
        public int idVeiculo { get; set; }
        public  ModeloDomains Modelo { get; set; }
        public EmpresaDomains Empresa { get; set;}
        public string placa { get; set; }
    }
}

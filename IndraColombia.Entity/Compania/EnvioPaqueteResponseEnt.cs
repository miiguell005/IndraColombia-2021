using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraColombia.Entity.Compania
{
    public class EnvioPaqueteResponseEnt
    {
        public List<int> Paquetes { get; set; }
        public int TamanioCamion { get; set; }
        public List<int> Solucion { get; set; }
        public string Resultado { get; set; }

    }
}

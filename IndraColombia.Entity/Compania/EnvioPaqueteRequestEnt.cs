using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraColombia.Entity.Barrio
{
    public class EnvioPaqueteRequestEnt
    {
        public List<int> lstPaquetes { get; set; }
        public int tamanioCamion { get; set; }
    }
}

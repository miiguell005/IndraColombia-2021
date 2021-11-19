using IndraColombia.Entity.Barrio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraColombia.LogicLayer.Barrio
{
    public class BarrioBLL
    {
        public CasasResponseEnt Competir(CasasRequestEnt casasRequest)
        {
            ValidarEstructuraCsas(casasRequest.lstCasas, casasRequest.dias);

            //El resultado en dia 0
            List<int> resultadoDia = casasRequest.lstCasas;

            //Resultado del dia n
            for (var i = 0; i < casasRequest.dias; i++)
                resultadoDia = DiaCompetenciaCasas(resultadoDia);

            return new CasasResponseEnt()
            {
                dias = casasRequest.dias,
                entrada = $"[{string.Join(",", casasRequest.lstCasas)}]",
                salida = $"[{string.Join(",", resultadoDia)}]"
            };
        }
        private void ValidarEstructuraCsas(List<int> casas, int dias)
        {
            var mensajeError = "";
            foreach (var c in casas)
                if (c != 0 && c != 1)
                {
                    mensajeError += "Error, las casas deben tener los valores de 1 ó 0 \n\n";
                    break;
                }

            if (casas.Count() != 8)
                mensajeError += "Error, la cantidad de casas aceptadas es de 8\nEjemplo \"[1, 1, 1, 0, 1, 1, 1, 1]\" \n\n";

            if (dias < 0)
                mensajeError += "La cantidad de dias no puede ser inferior a 1";

            if (!string.IsNullOrEmpty(mensajeError))
                throw new Exception(mensajeError);
        }
        private List<int> DiaCompetenciaCasas(List<int> casas)
        {
            var casasResponse = new List<int>();

            for (var i = 0; i < casas.Count(); i++)
            {
                var resultado = 0;

                if (i == 0)
                    resultado = CompetirCasasAdyacentes(0, casas[i + 1]);

                else if ((casas.Count() - 1) == i)
                    resultado = CompetirCasasAdyacentes(casas[i - 1], 0);

                else
                    resultado = CompetirCasasAdyacentes(casas[i - 1], casas[i + 1]);

                casasResponse.Add(resultado);
            }
            return casasResponse;
        }
        private int CompetirCasasAdyacentes(int izquierdo, int derecho)
        {
            return izquierdo == derecho ? 0 : 1;
        }
    }
}

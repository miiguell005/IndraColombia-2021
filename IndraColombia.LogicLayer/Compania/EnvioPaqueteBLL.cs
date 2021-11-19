using IndraColombia.Entity.Barrio;
using IndraColombia.Entity.Compania;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraColombia.LogicLayer.Compania
{
    public class EnvioPaqueteBLL
    {
        public EnvioPaqueteResponseEnt SeleccionPaquetes(EnvioPaqueteRequestEnt envioPaquetes)
        {
            ValidarPâquetes(envioPaquetes);

            //Configuracion del camion 
            var espacioLibre = 30;

            var paquetesOrganizados = envioPaquetes.lstPaquetes.OrderByDescending(p => p).ToList();

            //Selecciona que paquetes deben ir en el camion
            var solucion = SeleccionarCarga(paquetesOrganizados, (envioPaquetes.tamanioCamion - espacioLibre));

            var resultado = "";
            if (solucion.Count() == 0)
                resultado = "No se encontró una pareja de paquetes que quepa en el camion";
            else
                resultado = $"[{string.Join(",", solucion)}] -> La suma de los paquetes es {solucion.Sum()}, lo que permite dejar las {espacioLibre} unidades de espacio requeridas.";

            return new EnvioPaqueteResponseEnt()
            {
                Paquetes = envioPaquetes.lstPaquetes,
                TamanioCamion = envioPaquetes.tamanioCamion,
                Solucion = solucion.Count() == 0 ? null : solucion,
                Resultado = resultado
            };

        }
        private List<int> SeleccionarCarga(List<int> paquetes, int espacioLibre)
        {
            var paquetesSeleccionados = new List<int>();
            var sumatoria = 0;

            for(var i = 0; i < paquetes.Count(); i++)
            {
                for (var j = i; j < paquetes.Count(); j++)
                {
                    if((paquetes[i] + paquetes[j]) == espacioLibre) { 
                        paquetesSeleccionados = new List<int>() { paquetes[i], paquetes[j] };
                        sumatoria = (paquetes[i] + paquetes[j]);
                        break;
                    }
                    else if((paquetes[i] + paquetes[j]) < espacioLibre && (paquetes[i] + paquetes[j]) > sumatoria) {
                        sumatoria = (paquetes[i] + paquetes[j]);
                        paquetesSeleccionados = new List<int>() { paquetes[i], paquetes[j] };
                    }
                }
                if (sumatoria == espacioLibre)
                    break;
            }
            return paquetesSeleccionados;
        }
        private void ValidarPâquetes(EnvioPaqueteRequestEnt envioPaquetes)
        {
            var mensaje = "";

            foreach (var p in envioPaquetes.lstPaquetes)
                if (p < 1)
                {
                    mensaje += "El peso minimo del paquete es de 1\n\n";
                    break;
                }

            if (envioPaquetes.lstPaquetes.Count() < 2)
                mensaje += "Es necesario ingresar minimo 2 paquetes\n\n";

            if (envioPaquetes.tamanioCamion < 31)
                mensaje += "La capacidad del camion no puede ser inferior a 31\n\n";

            if (!string.IsNullOrEmpty(mensaje))
                throw new Exception(mensaje);
        }
    }
}

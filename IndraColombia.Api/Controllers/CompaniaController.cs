using IndraColombia.Entity.Barrio;
using IndraColombia.Entity.Compania;
using IndraColombia.LogicLayer.Compania;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndraColombia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniaController : ControllerBase
    {
        [HttpPost]
        [Route("Envio/Paquete")]
        public EnvioPaqueteResponseEnt PostEnvioPaquete(EnvioPaqueteRequestEnt envioPaquetes)
        {
            try
            {
                var compania = new EnvioPaqueteBLL();
                return compania.SeleccionPaquetes(envioPaquetes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            return "Hola mundo";
        }
    }
}

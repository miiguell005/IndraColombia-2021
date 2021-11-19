using IndraColombia.Entity.Barrio;
using IndraColombia.LogicLayer.Barrio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndraColombia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarrioController : ControllerBase
    {
        [HttpPost]
        [Route("Competencia/Casas")]
        public async Task<CasasResponseEnt> PostCompetenciaCasas(CasasRequestEnt casasRequest)
        {
            try
            {
                var barrioBLL = new BarrioBLL();
                return barrioBLL.Competir(casasRequest);
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

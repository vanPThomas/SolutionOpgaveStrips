using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.DTO;
using StripsREST.Mappers;

namespace StripsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = "http://localhost:5044/api/strips/beheer";

        public StripsController(StripsManager stripsManager)
        {
            this.stripsManager = stripsManager;
        }

        [Route("[Action]/{reeksId:int=3}")]
        [HttpGet]
        public ActionResult<ReeksDTO> GetReeks(int reeksId)
        {
            try
            {
                Reeks reeks = stripsManager.GeefReeksMetStrips(reeksId);
                return Ok(MapFromDomain.MapFromReeksDomain(url, reeks));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

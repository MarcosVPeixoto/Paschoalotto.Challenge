using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Challenge.IBusiness.IBusiness;

namespace Paschoalotto.Challange.API.Controllers
{
    [ApiController]
    [Route("Personagem")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemBusiness _business;

        public PersonagemController(IPersonagemBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("PreencherArquivo")]
        public async Task<IActionResult> PreencherArquivo()
        {
            await _business.PreencherArquivo();
            return Ok();
        }

    }
}

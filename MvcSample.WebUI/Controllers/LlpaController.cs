using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Interfaces;
using System.Threading;

namespace MvcSample.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LlpaController : ControllerBase
    {
        private readonly ILlpaService _llpaService;

        public LlpaController(ILlpaService llpaService)
        {
            _llpaService = llpaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LlpaUpsertDto dto, CancellationToken cancellationToken)
        {
            await _llpaService.CreateAsync(dto, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LlpaLookupDto>>> Get()
        {
            var dtos = await _llpaService.GetAllAsync();

            return Ok(dtos);
        }
    }
}

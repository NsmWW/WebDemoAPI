using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDemoAPI.Application.ConstanConnection;
using WebDemoAPI.Application.InterfaceService;
using WebDemoAPI.Application.Payload.Resquest.UserResquest;

namespace WebDemoAPI.Controllers
{
    [Route(Contans.defaulValue.DEFAULT_CONTROLER_ROUTER)]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAservice _aservice;

        public ValuesController(IAservice aservice)
        {
            _aservice = aservice;
        }
        [HttpPost]
        public async Task<IActionResult> Regitster([FromBody] Request_Register request_Register)
        {
            return Ok(await _aservice.Register(request_Register));
        }
    }
}

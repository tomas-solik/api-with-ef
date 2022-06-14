using Demo.Dal.Interface;
using Demo.Dal.Interface.Types;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : Controller
    {
        private readonly ILogger<DemoController> _logger;

        private readonly IToolService _toolService;

        public DemoController(ILogger<DemoController> logger, IToolService toolService)
        {
            _logger = logger;
            _toolService = toolService;
        }

        [HttpGet(Name = "GetTools")]
        public ActionResult<List<ToolDto>> Get()
        {
            var tools = _toolService.GetTools();
            return Ok(tools);
        }
    }
}
